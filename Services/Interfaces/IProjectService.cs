using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<bool> AddMemberToProjectAsync(BTUser member, int projectId);        
        public Task AddProjectAsync(Project project);
        public Task<bool> AddProjectManagerAsync(string userId, int projectId);
        public Task ArchiveProjectAsync(Project project);
        public Task<List<Project>> GetAllProjectsByCompanyIdAsync(int companyId);
        public Task<List<Project>> GetArchivedProjectsByCompanyIdAsync(int companyId);
        public Task<int> GetCompanyId(string userId);
        public Task<List<Project>?> GetUserProjectsAsync(string userId);
        public Task<Project> GetProjectByIdAsync(int projectId, int companyId);
        public Task<BTUser> GetProjectManagerAsync(int projectId);
        public Task<IEnumerable<ProjectPriority>> GetProjectPrioritiesAsync();
        public Task<bool> RemoveMemberFromProjectAsync(BTUser member, int projectId);
        public Task RemoveProjectManagerAsync(int projectId);
        public Task RestoreProjectAsync(Project project);
        public Task UpdateProjectAsync(Project project);
    }
}
