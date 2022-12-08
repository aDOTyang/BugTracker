using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface ITicketService
    {
        public Task<bool> AddDeveloperToTicketAsync(string userId, int projectId, int companyId);
        public Task AddTicketAsync(Ticket ticket);
        public Task AddTicketAttachmentAsync(TicketAttachment ticketAttachment);
        public Task ArchiveTicketAsync(Ticket ticket);
        public Task<List<Ticket>> GetAllTicketsByCompanyIdAsync(int companyId);
        public Task<List<Ticket>> GetAllTicketsByProjectIdAsync(int projectId);
        public Task<List<Ticket>> GetArchivedTicketsByProjectIdAsync(int projectId);
        public Task<BTUser> GetDeveloperAsync(int ticketId, int companyId);
        public Task<List<BTUser>> GetDevelopersByCompanyAsync(int companyId);
        public Task<Ticket> GetTicketAsNoTrackingAsync(int ticketId, int companyId);
        public Task<TicketAttachment> GetTicketAttachmentByIdAsync(int ticketAttachmentId);
        public Task<Ticket> GetTicketByIdAsync(int ticketId, int companyId);
        public Task<List<Ticket>> GetTicketsByUserIdAsync(string userId, int companyId);
        public Task<List<TicketPriority>> GetTicketPrioritiesAsync();
        public Task<List<TicketStatus>> GetTicketStatusesAsync();
        public Task<List<TicketType>> GetTicketTypesAsync();
        public Task RemoveDeveloperAsync(int projectId, int companyId);
        public Task RestoreTicketAsync(Ticket ticket);
        public Task UpdateTicketAsync(Ticket ticket);
    }
}
