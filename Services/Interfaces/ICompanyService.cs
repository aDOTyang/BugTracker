using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<List<BTUser>> GetMembersAsync(int? companyId);
    }
}
