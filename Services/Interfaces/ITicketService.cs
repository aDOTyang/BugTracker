using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface ITicketService
    {
        public Task<List<Ticket>> GetAllTicketsByCompanyIdAsync(int companyId);
        public Task<List<Ticket>> GetAllTicketsByProjectIdAsync(int projectId);
        public Task<List<Ticket>> GetArchivedTicketsByProjectIdAsync(int projectId);
        public Task AddTicketAsync(Ticket ticket);
        public Task<Ticket> GetTicketByIdAsync(int ticketId, int companyId);
        public Task<List<TicketPriority>> GetTicketPrioritiesAsync();
        public Task<List<TicketStatus>> GetTicketStatusesAsync();
        public Task<List<TicketType>> GetTicketTypesAsync();
        public Task UpdateTicketAsync(Ticket ticket);
        public Task ArchiveTicketAsync(Ticket ticket);
        public Task RestoreTicketAsync(Ticket ticket);
    }
}
