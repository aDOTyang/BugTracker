using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Models.Enums;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace BugTracker.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRolesService _rolesService;
        private readonly UserManager<BTUser> _userManager;

        public ProjectService(ApplicationDbContext context, IRolesService rolesService, UserManager<BTUser> userManager)
        {
            _context = context;
            _rolesService = rolesService;
            _userManager = userManager;
        }

        public async Task<bool> AddMemberToProjectAsync(BTUser member, int projectId)
        {
            try
            {
                Project? project = await GetProjectByIdAsync(projectId, member.CompanyId);

                bool IsOnProject = project.Members.Any(m => m.Id == member.Id);

                if (!IsOnProject)
                {
                    project.Members.Add(member);
                    await _context.SaveChangesAsync();
                    // bool false by default, method only returns true if member add successful
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddProjectAsync(Project project)
        {
            try
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddProjectManagerAsync(string userId, int projectId)
        {
            try
            {
                BTUser? currentPM = await GetProjectManagerAsync(projectId);
                BTUser? selectedPM = await _context.Users.FindAsync(userId);

                if (currentPM != null)
                {
                    await RemoveProjectManagerAsync(projectId);
                }

                try
                {
                    await AddMemberToProjectAsync(selectedPM!, projectId);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ArchiveProjectAsync(Project project)
        {
            try
            {
                if (project != null && project.Archived == false)
                {
                    project.Archived = true;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Project>> GetAllProjectsByCompanyIdAsync(int companyId)
        {
            try
            {
                List<Project> projects = await _context.Projects.Where(c => c.CompanyId == companyId && c.Archived == false)
                                                                .Include(p => p.Company)
                                                                .Include(p => p.ProjectPriority)
                                                                .Include(p => p.Members)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.Comments)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.Attachments)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.History)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketPriority)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketStatus)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketType)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.SubmitterUser)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.DeveloperUser)
                                                                .OrderByDescending(c => c.Name).ToListAsync();
                return projects;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Project>> GetAllProjectsByPriorityAsync(int companyId, string priority)
        {
            try
            {
                List<Project> projects = await _context.Projects.Where(c => c.CompanyId == companyId && c.Archived == false && c.ProjectPriority.Name == priority)
                                                                .Include(p => p.Company)
                                                                .Include(p => p.ProjectPriority)
                                                                .Include(p => p.Members)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.Comments)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.Attachments)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.History)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketPriority)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketStatus)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.TicketType)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.SubmitterUser)
                                                                .Include(p => p.Tickets).ThenInclude(t => t.DeveloperUser)
                                                                .OrderByDescending(c => c.Id).ToListAsync();
                return projects;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Project>> GetArchivedProjectsByCompanyIdAsync(int companyId)
        {
            try
            {
                List<Project> projects = await _context.Projects.Where(c => c.CompanyId == companyId && c.Archived == true)
                                                                .Include(p => p.Company).Include(p => p.ProjectPriority)
                                                                .Include(p => p.Tickets).Include(p => p.Members)
                                                                .OrderByDescending(c => c.Name).ToListAsync();
                return projects;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Project>?> GetUserProjectsAsync(string userId)
        {
            if (await _rolesService.IsUserInRoleAsync(await _userManager.FindByIdAsync(userId), nameof(BTRoles.Admin)))
            {
                int companyId = (await _userManager.FindByIdAsync(userId)).CompanyId;
                List<Project>? projects = (await GetAllProjectsByCompanyIdAsync(companyId)).Where(p=>p.Archived == false).ToList();
                return projects;
            } else {

                List<Project>? projects = (await _context.Users.Include(p => p.Projects).ThenInclude(p => p.ProjectPriority)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Members)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.Comments)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.Attachments)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.History)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.TicketPriority)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.TicketStatus)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.TicketType)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.SubmitterUser)
                                                               .Include(p => p.Projects).ThenInclude(p => p.Tickets).ThenInclude(t => t.DeveloperUser)
                                                               .FirstOrDefaultAsync(p => p.Id == userId))?
                                                               .Projects.Where(p => p.Archived == false).ToList();
                return projects;
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id, int companyId)
        {
            try
            {
                Project? project = await _context.Projects.Include(p => p.Company)
                                                          .Include(p => p.Members)
                                                          .Include(p => p.ProjectPriority)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.TicketPriority)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.TicketStatus)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.TicketType)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.History)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.Attachments)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.Comments)
                                                          .FirstOrDefaultAsync(p => p.Id == id && p.CompanyId == companyId);
                return project!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BTUser> GetProjectManagerAsync(int projectId)
        {
            try
            {
                Project? project = await _context.Projects.Include(p => p.Members).FirstOrDefaultAsync(p => p.Id == projectId);

                foreach (BTUser member in project!.Members)
                {
                    if (await _rolesService.IsUserInRoleAsync(member, nameof(BTRoles.ProjectManager)))
                    {
                        return member;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProjectPriority>> GetProjectPrioritiesAsync()
        {
            try
            {
                return await _context.ProjectPriorities.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveMemberFromProjectAsync(BTUser member, int projectId)
        {
            try
            {
                Project? project = await GetProjectByIdAsync(projectId, member.CompanyId);

                bool IsOnProject = project.Members.Any(m => m.Id == member.Id && m.CompanyId == project.CompanyId);

                if (IsOnProject)
                {
                    project.Members.Remove(member);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveProjectManagerAsync(int projectId)
        {
            try
            {
                BTUser? currentPM = await GetProjectManagerAsync(projectId);

                if (currentPM != null)
                {
                    Project? project = await GetProjectByIdAsync(projectId, currentPM.CompanyId);
                    project.Members.Remove(currentPM);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RestoreProjectAsync(Project project)
        {
            try
            {
                await _context.Projects.FindAsync(project.Id);

                if (project != null && project.Archived == true)
                {
                    project.Archived = false;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProjectAsync(Project project)
        {
            try
            {
                _context.Update(project);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
