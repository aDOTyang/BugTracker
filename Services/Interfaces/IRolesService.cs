using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IRolesService
    {
        public Task<List<BTUser>> GetUsersInRoleAsync(string roleName, int companyId);

        public Task<bool> IsUserInRole(BTUser member, string roleName);
    }
}
