using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Models.Enums;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using Project = BugTracker.Models.Project;

namespace BugTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRolesService _rolesService;
        private readonly IProjectService _projectService;

        public TicketService(ApplicationDbContext context, IRolesService rolesService, IProjectService projectService)
        {
            _context = context;
            _rolesService = rolesService;
            _projectService = projectService;
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddTicketAttachmentAsync(TicketAttachment ticketAttachment)
        {
            try
            {
                await _context.AddAsync(ticketAttachment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddDeveloperToTicketAsync(string userId, int ticketId, int companyId)
        {
            try
            {
                Ticket? ticket = await GetTicketByIdAsync(ticketId, companyId);

                try
                {
                    ticket.DeveloperUserId = userId;
                    await UpdateTicketAsync(ticket);
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
            List<Ticket> tickets = await _context.Tickets.Where(c => c.SubmitterUser!.CompanyId == companyId)
                                                         .Include(c => c.DeveloperUser)
                                                         .Include(c => c.Project)
                                                         .Include(c => c.TicketStatus)
                                                         .Include(c => c.TicketType)
                                                         .Include(c => c.History)
                                                         .Include(c => c.TicketPriority).OrderByDescending(c => c.TicketPriority).ToListAsync();
            return tickets;
        }

        public async Task<List<Ticket>> GetAllTicketsByProjectIdAsync(int projectId)
        {
            try
            {
                List<Ticket> tickets = await _context.Tickets.Where(c => c.ProjectId == projectId && c.Archived == false).OrderByDescending(c => c.Updated).ToListAsync();
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
                List<Ticket> tickets = await _context.Tickets.Where(t => t.ProjectId == projectId && t.Archived == true).Include(t => t.DeveloperUser)
                .Include(t => t.Project).Include(t => t.SubmitterUser).Include(t => t.TicketPriority).Include(t => t.TicketStatus).Include(t => t.TicketType).OrderByDescending(t => t.Updated).ToListAsync();

                return tickets;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BTUser> GetDeveloperAsync(int ticketId, int companyId)
        {
            try
            {
                Ticket? ticket = (await GetTicketByIdAsync(ticketId, companyId));

                if (ticket.DeveloperUserId == null)
                {
                    return null!;
                }

                return (await _context.Users.FirstOrDefaultAsync(u => u.Id == ticket.DeveloperUserId))!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BTUser>> GetDevelopersByCompanyAsync(int companyId)
        {
            try
            {
                //Project project = await _projectService.GetProjectByIdAsync(projectId, companyId);
                List<BTUser> developers = _context.Users.Where(p => p.CompanyId == companyId).ToList();
                return developers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Ticket> GetTicketAsNoTrackingAsync(int ticketId, int companyId)
        {
            try
            {
                Ticket? ticket = await _context.Tickets.Include(p => p.Project)
                                       .Include(p => p.TicketPriority)
                                       .Include(p => p.TicketStatus)
                                       .Include(p => p.TicketType)
                                       .Include(p => p.SubmitterUser)
                                       .Include(p => p.DeveloperUser)
                                       .Include(p => p.Comments)
                                       .Include(p => p.History)
                                       .Include(p => p.Attachments)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(p => p.Id == ticketId && p.SubmitterUser!.CompanyId == companyId && p.Archived == false);
                return ticket!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TicketAttachment> GetTicketAttachmentByIdAsync(int ticketAttachmentId)
        {
            try
            {
                TicketAttachment? ticketAttachment = await _context.TicketAttachments
                                                                  .Include(t => t.User)
                                                                  .FirstOrDefaultAsync(t => t.Id == ticketAttachmentId);
                return ticketAttachment!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId, int companyId)
        {
            try
            {
                Ticket? ticket = await _context.Tickets.Include(p => p.Project)
                                                       .Include(p => p.TicketPriority)
                                                       .Include(p => p.TicketStatus)
                                                       .Include(p => p.TicketType)
                                                       .Include(p => p.SubmitterUser)
                                                       .Include(p => p.DeveloperUser)
                                                       .Include(p => p.Comments)
                                                       .Include(p => p.History)
                                                       .Include(p => p.Attachments)
                                                       .FirstOrDefaultAsync(p => p.Id == ticketId && p.SubmitterUser!.CompanyId == companyId && p.ArchivedByProject == false);
                return ticket!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetTicketsByUserIdAsync(string userId, int companyId)
        {
            BTUser? btUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            List<Ticket>? tickets = (await _projectService.GetAllProjectsByCompanyIdAsync(companyId)).Where(p => p.Archived == false)
                                                          .SelectMany(p => p.Tickets!).Where(t => !(t.Archived | t.ArchivedByProject)).ToList();
            // binary or operator (single pipe) returns 1 (true) unless both bool return 0, in which case it returns 0 (false)
            try
            {
                if (await _rolesService.IsUserInRoleAsync(btUser!, nameof(BTRoles.Admin)))
                {
                    return tickets;
                    //= (await _projectService.GetAllProjectsByCompanyIdAsync(companyId)).SelectMany(p => p.Tickets!).ToList();
                }
                else if (await _rolesService.IsUserInRoleAsync(btUser!, nameof(BTRoles.Developer)))
                {
                    return tickets.Where(t => t.DeveloperUserId == userId || t.SubmitterUserId == userId).ToList();
                }
                else if (await _rolesService.IsUserInRoleAsync(btUser!, nameof(BTRoles.Submitter)))
                {
                    return tickets.Where(t => t.SubmitterUserId == userId).ToList();
                }
                else if (await _rolesService.IsUserInRoleAsync(btUser!, nameof(BTRoles.ProjectManager)))
                {
                    List<Ticket>? projectTickets = (await _projectService.GetUserProjectsAsync(userId))!.SelectMany(t => t.Tickets!).Where(t => !(t.Archived | t.ArchivedByProject)).ToList();
                    List<Ticket>? submittedTickets = tickets.Where(t => t.SubmitterUserId == userId).ToList();
                    return tickets = projectTickets.Concat(submittedTickets).ToList();
                }
                else
                {
                    return tickets;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TicketPriority>> GetTicketPrioritiesAsync()
        {
            try
            {
                List<TicketPriority>? ticketPriorities = await _context.TicketPriorities.ToListAsync();

                return ticketPriorities!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketStatus>> GetTicketStatusesAsync()
        {
            try
            {
                List<TicketStatus>? ticketStatuses = await _context.TicketStatuses.ToListAsync();

                if (ticketStatuses != null)
                {
                    return ticketStatuses;
                }

                return ticketStatuses!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketType>> GetTicketTypesAsync()
        {
            try
            {
                List<TicketType>? ticketTypes = await _context.TicketTypes.ToListAsync();

                return ticketTypes!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveDeveloperAsync(int ticketId, int companyId)
        {
            try
            {
                Ticket? ticket = await GetTicketByIdAsync(ticketId, companyId);
                Project? project = await _projectService.GetProjectByIdAsync(ticket.ProjectId, companyId);
                BTUser? currentDev = await GetDeveloperAsync(ticketId, companyId);

                if (currentDev != null)
                {
                    project.Members.Remove(currentDev);
                    await _context.SaveChangesAsync();
                }
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
                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
