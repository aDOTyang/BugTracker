using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace BugTracker.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;
        private readonly IRolesService _rolesService;

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
            throw new NotImplementedException();
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
                                                                .Include(p => p.Company).Include(p => p.ProjectPriority)
                                                                .Include(p=>p.Tickets).Include(p=>p.Members)
                                                                .OrderByDescending(c => c.Name).ToListAsync();
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
                List<Project> projects = await _context.Projects.Where(c => c.CompanyId == companyId && c.Archived == true).OrderByDescending(c => c.Name).ToListAsync();
                return projects;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<Project> GetProjectByIdAsync(int id, int companyId)
        {
            try
            {
                Project? project = await _context.Projects.Include(p => p.Company)
                                                          .Include(p=>p.Members)
                                                          .Include(p => p.ProjectPriority)
                                                          .Include(p => p.Tickets).ThenInclude(p=>p.TicketPriority)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.TicketStatus)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.TicketType)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.History)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.Attachments)
                                                          .Include(p => p.Tickets).ThenInclude(p => p.Comments)
                                                          .FirstOrDefaultAsync(p => p.Id == id && p.CompanyId == companyId);
                return project;
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

                bool IsOnProject = project.Members.Any(m => m.Id == member.Id);

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
            throw new NotImplementedException();
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
