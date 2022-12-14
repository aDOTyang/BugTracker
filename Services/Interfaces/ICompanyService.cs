using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<Company> GetCompanyInfoAsync(int? companyId);
        public Task<List<BTUser>> GetMembersAsync(int? companyId);
    }
}
