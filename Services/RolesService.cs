using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Services
{
    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;

        public RolesService(ApplicationDbContext context, UserManager<BTUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<BTUser>> GetUsersInRoleAsync(string roleName, int companyId)
        {
            try
            {
                // uses userManager method - our RolesService method is named the same for ease of use where userManager is unavailable
                List<BTUser> users = (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
                List<BTUser> result = users.Where(u => u.CompanyId == companyId).OrderByDescending(u => u.LastName).ThenByDescending(u => u.FirstName).ToList(); 
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsUserInRoleAsync(BTUser member, string roleName)
        {
            try
            {
                return await _userManager.IsInRoleAsync(member, roleName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
