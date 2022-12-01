using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace BugTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ArchiveTicketAsync(Ticket ticket)
        {
            try
            {
                if (ticket != null && ticket.Archived == false)
                {
                    ticket.Archived = true;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTicketsByCompanyIdAsync(int companyId)
        {
            List<Ticket> tickets = await _context.Tickets.Where(c => c.SubmitterUser!.CompanyId == companyId && c.Archived == false).OrderByDescending(c => c.Updated).ToListAsync();
            return tickets;
        }

        public async Task<List<Ticket>> GetAllTicketsByProjectIdAsync(int projectId)
        {
            try
            {
                List<Ticket> tickets = await _context.Tickets.Where(c => c.ProjectId == projectId && c.Archived == false).OrderByDescending(c=>c.Updated).ToListAsync();
                return tickets;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Ticket>> GetArchivedTicketsByProjectIdAsync(int projectId)
        {
            try
            {
                List<Ticket> tickets = await _context.Tickets.Where(t=>t.ProjectId == projectId && t.Archived == true).Include(t => t.DeveloperUser)
                .Include(t => t.Project).Include(t => t.SubmitterUser).Include(t => t.TicketPriority).Include(t => t.TicketStatus).Include(t => t.TicketType).OrderByDescending(t=>t.Updated).ToListAsync();

                return tickets;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId, int projectId)
        {
            try
            {
                // int companyId = (await _userManager.GetUserAsync(User)).CompanyId;
                Ticket? ticket = await _context.Tickets.Include(p => p.Project)
                                                   .Include(p => p.TicketPriority)
                                                   .Include(p => p.TicketStatus)
                                                   .Include(p => p.TicketType)
                                                   .Include(p => p.SubmitterUser)
                                                   .Include(p => p.DeveloperUser)
                                                   .Include(p => p.Comments)
                                                   .Include(p => p.History)
                                                   .Include(p => p.Attachments)
                                                   .FirstOrDefaultAsync(p => p.Id == ticketId && p.ProjectId == projectId);
                return ticket!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RestoreTicketAsync(Ticket ticket)
        {
            try
            {
                await _context.Projects.FindAsync(ticket.Id);

                if (ticket != null && ticket.Archived == true)
                {
                    ticket.Archived = false;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Update(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
