using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BugTracker.Extensions;
using BugTracker.Models.Enums;
using BugTracker.Models.ViewModels;
using BugTracker.Services;
using System.ComponentModel.Design;
using System.Net.Sockets;
using Org.BouncyCastle.Bcpg;

namespace BugTracker.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly UserManager<BTUser> _userManager;
        private readonly IFileService _fileService;
        private readonly IProjectService _projectService;
        private readonly IRolesService _rolesService;
        private readonly ICompanyService _companyService;

        public ProjectsController(UserManager<BTUser> userManager, IFileService fileService, IProjectService projectService, IRolesService rolesService, ICompanyService companyService)
        {
            _userManager = userManager;
            _fileService = fileService;
            _projectService = projectService;
            _rolesService = rolesService;
            _companyService = companyService;
        }

        //GET: Projects
        public async Task<IActionResult> MyProjects()
        {
            List<Project> projects = (await _projectService.GetUserProjectsAsync((await _userManager.GetUserAsync(User)).Id))!.ToList();
            return View(projects);
        }

        /// <summary>
        /// admin index - all company projects shown
        /// </summary>
        /// <returns></returns>
        // GET: Projects
        public async Task<IActionResult> Index()
        {
            int companyId = User.Identity!.GetCompanyId();
            List<Project>? projects = await _projectService.GetAllProjectsByCompanyIdAsync(companyId);
            return View(projects);
        }

        // GET: Projects/Unassigned
        public async Task<IActionResult> Unassigned()
        {
            int companyId = User.Identity!.GetCompanyId();

            List<Project>? projects = new();

            if (User.IsInRole("Admin"))
            {
                projects = await _projectService.GetAllProjectsByCompanyIdAsync(companyId);
            }
            else
            {
                string userId = _userManager.GetUserId(User);
                projects = await _projectService.GetUserProjectsAsync(userId);
            }

            return View(projects);
        }

        [HttpGet]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        // GET: Projects/AssignPM
        public async Task<IActionResult> AssignPM(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<BTUser> projectManagers = await _rolesService.GetUsersInRoleAsync(nameof(BTRoles.ProjectManager), User.Identity!.GetCompanyId());
            BTUser? currentPM = await _projectService.GetProjectManagerAsync(id.Value);

            AssignPMViewModel viewModel = new()
            {
                Project = await _projectService.GetProjectByIdAsync(id.Value, User.Identity!.GetCompanyId()),
                PMList = new SelectList(projectManagers, "Id", "FullName", currentPM?.Id),
                PMId = currentPM?.Id
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        // POST: Projects/AssignPM
        public async Task<IActionResult> AssignPM(AssignPMViewModel viewModel)
        {
            if (viewModel.Project?.Id != null)
            {
                if (!string.IsNullOrEmpty(viewModel.PMId))
                {
                    await _projectService.AddProjectManagerAsync(viewModel.PMId, viewModel.Project.Id);
                }
                else
                {
                    await _projectService.RemoveProjectManagerAsync(viewModel.Project.Id);
                }
                return RedirectToAction(nameof(Details), new { id = viewModel.Project?.Id });
            }
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        // POST: Projects/AddMember
        public async Task<IActionResult> AddMember(BTUser member, int projectId, string memberName)
        {
            if (member != null && projectId != null)
            {
                string[] fName = memberName.Split(' ');
                member.FirstName = fName[0];
                member.LastName = fName[1];

                await _projectService.AddMemberToProjectAsync(member, projectId);
                return RedirectToAction(nameof(Details),"Projects", new { id = projectId });
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        // POST: Projects/RemoveMember
        public async Task<IActionResult> RemoveMember(BTUser member, int projectId)
        {
            if (member != null && projectId != null)
            {
                await _projectService.RemoveMemberFromProjectAsync(member, projectId);
                return RedirectToAction(nameof(Details), new { id = projectId });
            }
            return View();
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);

            if (project == null)
            {
                return NotFound();
            }

            ViewData["Members"] = new SelectList(await _companyService.GetMembersAsync(companyId), "FullName", "FullName");
            return View(project);
        }

        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        // GET: Projects/Create
        public async Task<IActionResult> Create()
        {
            int companyId = User.Identity!.GetCompanyId();
            ViewData["ProjectManager"] = new SelectList((await _userManager.GetUsersInRoleAsync("ProjectManager")).Where(m => m.CompanyId == companyId), "Id", "FullName");
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name");
            return View(new Project());
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,ProjectPriorityId,Name,Description,StartDate,EndDate,ImageFormFile,Archived")] Project project, string PMId)
        {
            ModelState.Remove("CompanyId");

            if (string.IsNullOrEmpty(PMId))
            {
                ModelState.Remove("PMId");
            }

            if (ModelState.IsValid)
            {
                int companyId = User.Identity!.GetCompanyId();
                project.CompanyId = companyId;
                project.Created = DateTime.UtcNow;

                if (project.StartDate != null)
                {
                    project.StartDate = DateTime.SpecifyKind(project.StartDate.Value, DateTimeKind.Utc);
                }

                if (project.EndDate != null)
                {
                    project.EndDate = DateTime.SpecifyKind(project.EndDate.Value, DateTimeKind.Utc);
                }

                if (project.ImageFormFile != null)
                {
                    project.ImageFileData = await _fileService.ConvertFileToByteArrayAsync(project.ImageFormFile);
                    project.ImageFileType = project.ImageFormFile.ContentType;
                }

                // this addproject method creates the project, after which the id can be accessed
                await _projectService.AddProjectAsync(project);
                if (!string.IsNullOrEmpty(PMId))
                {
                    await _projectService.AddProjectManagerAsync(PMId, project.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectManager"] = new SelectList((await _userManager.GetUsersInRoleAsync("ProjectManager")).Where(m => m.CompanyId == project.CompanyId), "Id", "FullName", PMId);
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name", project.ProjectPriorityId);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        public async Task<IActionResult> Edit(int? id, string PMId)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);

            if (project == null)
            {
                return NotFound();
            }
            ViewData["ProjectManager"] = new SelectList((await _userManager.GetUsersInRoleAsync("ProjectManager")).Where(m => m.CompanyId == project.CompanyId), "Id", "FullName", PMId);
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name", project.ProjectPriorityId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ProjectPriorityId,Name,Description,StartDate,EndDate,Created,ImageFormFile,Archived")] Project project, string PMId)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(PMId))
            {
                ModelState.Remove("PMId");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    project.Created = DateTime.SpecifyKind(project.Created, DateTimeKind.Utc);

                    if (project.ImageFormFile != null)
                    {
                        project.ImageFileData = await _fileService.ConvertFileToByteArrayAsync(project.ImageFormFile);
                        project.ImageFileType = project.ImageFormFile.ContentType;
                    }

                    if (project.StartDate != null)
                    {
                        project.StartDate = DateTime.SpecifyKind(project.StartDate.Value, DateTimeKind.Utc);
                    }

                    if (project.EndDate != null)
                    {
                        project.EndDate = DateTime.SpecifyKind(project.EndDate.Value, DateTimeKind.Utc);
                    }

                    await _projectService.UpdateProjectAsync(project);
                    if (!string.IsNullOrEmpty(PMId))
                    {
                        await _projectService.RemoveProjectManagerAsync(project.Id);
                        await _projectService.AddProjectManagerAsync(PMId, project.Id);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (ProjectExists(project.Id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectManager"] = new SelectList((await _userManager.GetUsersInRoleAsync("ProjectManager")).Where(m => m.CompanyId == project.CompanyId), "Id", "FullName", PMId);
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name", project.ProjectPriorityId);
            return View(project);
        }


        //// GET: Projects/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects
        //        .Include(p => p.Company)
        //        .Include(p => p.ProjectPriority)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(project);
        //}

        //// POST: Projects/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Projects == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Projects'  is null.");
        //    }
        //    var project = await _context.Projects.FindAsync(id);
        //    if (project != null)
        //    {
        //        _context.Projects.Remove(project);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        // GET: Projects/Archive/5
        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        public async Task<IActionResult> Archive()
        {
            int companyId = User.Identity!.GetCompanyId();
            List<Project> projects = await _projectService.GetArchivedProjectsByCompanyIdAsync(companyId);

            return View(projects);
        }

        /// <summary>
        /// archives project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Projects/Archive/5
        [HttpPost, ActionName("Archive")]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);

            foreach(Ticket ticket in project.Tickets)
            {
                ticket.ArchivedByProject = true;
            }

            await _projectService.ArchiveProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// restores archived project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Projects/Restore/5
        [HttpPost, ActionName("Restore")]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);

            foreach (Ticket ticket in project.Tickets)
            {
                ticket.ArchivedByProject = false;
            }

            await _projectService.RestoreProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjectExists(int id)
        {
            int companyId = User.Identity!.GetCompanyId();
            return (await _projectService.GetAllProjectsByCompanyIdAsync(companyId)).Any(e => e.Id == id);
        }
    }
}