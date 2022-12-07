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

namespace BugTracker.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly UserManager<BTUser> _userManager;
        private readonly IFileService _fileService;
        private readonly IProjectService _projectService;
        private readonly IRolesService _rolesService;

        public ProjectsController(UserManager<BTUser> userManager, IFileService fileService, IProjectService projectService, IRolesService rolesService)
        {
            _userManager = userManager;
            _fileService = fileService;
            _projectService = projectService;
            _rolesService = rolesService;
        }

        // GET: Projects
        //public async Task<IActionResult> MyProjects()
        //{
        //    int companyId = (await _userManager.GetUserAsync(User)).CompanyId;

        //    if (User.IsInRole("Admin"))
        //    {
        //        List<Project> projects = await _projectService.GetMyProjectsAsync(userId, companyId);
        //        return View(projects);
        //    }
        //    else
        //    {

        //    }
        //}

        /// <summary>
        /// admin index - all company projects shown
        /// </summary>
        /// <returns></returns>
        // GET: Projects
        public async Task<IActionResult> Index()
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

            return View(project);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name");
            return View(new Project());
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, ProjectManager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,ProjectPriorityId,Name,Description,StartDate,EndDate,ImageFormFile,Archived")] Project project)
        {
            ModelState.Remove("CompanyId");
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

                await _projectService.AddProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name", project.ProjectPriorityId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            // ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", project.CompanyId);
            ViewData["ProjectPriorityId"] = new SelectList(await _projectService.GetProjectPrioritiesAsync(), "Id", "Name", project.ProjectPriorityId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, ProjectManager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,ProjectPriorityId,Name,Description,StartDate,EndDate,Created,ImageFormFile,Archived")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
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
        [Authorize(Roles = "Admin, Project Manager")]
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Project project = await _projectService.GetProjectByIdAsync(id.Value, companyId);
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