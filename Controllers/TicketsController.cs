using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BugTracker.Models.Enums;
using BugTracker.Services;
using BugTracker.Extensions;
using System.ComponentModel.Design;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly UserManager<BTUser> _userManager;
        private readonly ITicketService _ticketService;
        private readonly IProjectService _projectService;

        public TicketsController(UserManager<BTUser> userManager, ITicketService ticketService, IProjectService projectService)
        {
            _userManager = userManager;
            _ticketService = ticketService;
            _projectService = projectService;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            //int companyId = (await _userManager.GetUserAsync(User)).CompanyId;
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId))
                                                        .Where(c=>c.Archived == false && c.ArchivedByProject == false).ToList();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? ticketId)
        {
            if (ticketId == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Ticket? ticket = await _ticketService.GetTicketByIdAsync(ticketId.Value, companyId);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create()
        {
            int companyId = User.Identity!.GetCompanyId();
            ViewData["ProjectId"] = new SelectList(await _projectService.GetAllProjectsByCompanyIdAsync(companyId), "Id", "Name");
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name");
            //ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Name");
            ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name");
            //ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,TicketPriorityId,TicketTypeId,Title,Description")] Ticket ticket)
        {
            ModelState.Remove("SubmitterUserId");

            if (ModelState.IsValid)
            {
                ticket.SubmitterUserId = _userManager.GetUserId(User);
                ticket.Created = DateTime.UtcNow;
                ticket.TicketStatusId = (await _ticketService.GetTicketStatusesAsync()).FirstOrDefault(t => t.Name == nameof(BTTicketStatuses.New))!.Id;

                if (ticket.Updated != null)
                {
                    ticket.Updated = DateTime.SpecifyKind(ticket.Updated.Value, DateTimeKind.Utc);
                }

                await _ticketService.AddTicketAsync(ticket);
                return RedirectToAction(nameof(Index));
            }

            int companyId = User.Identity!.GetCompanyId();
            //ViewData["DeveloperUser"] = new SelectList(_context.Users, "Id", "Name", ticket.DeveloperUser!.FullName);
            ViewData["ProjectId"] = new SelectList(await _projectService.GetAllProjectsByCompanyIdAsync(companyId), "Id", "Name");
            ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name");
            ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Edit/5

        public async Task<IActionResult> Edit(int? ticketId)
        {
            if (ticketId == null)
            {
                return NotFound();
            }

            string userId = _userManager.GetUserId(User);
            int companyId = User.Identity!.GetCompanyId();

            // TODO: compare ticket to user for submitter/developer/PM

            if (User.IsInRole(nameof(BTRoles.Admin)))
            {
                Ticket? ticket = await _ticketService.GetTicketByIdAsync(ticketId.Value, companyId);

                if (ticket == null)
                {
                    return NotFound();
                }

                //ViewData["DeveloperUser"] = new SelectList(_context.Users, "Id", "Name", ticket.DeveloperUser!.FullName);
                ViewData["TicketStatusId"] = new SelectList(await _ticketService.GetTicketStatusesAsync(), "Id", "Name", ticket.TicketStatusId);
                ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name", ticket.TicketPriorityId);
                ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name", ticket.TicketTypeId);

                return View(ticket);
            }
            return NotFound();
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,TicketTypeId,TicketStatusId,TicketPriorityId,DeveloperUserId,SubmitterUserId,Title,Description,Created,Updated,Archived,ArchivedByProject")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.Created = DateTime.SpecifyKind(ticket.Created, DateTimeKind.Utc);
                    ticket.Updated = DateTime.UtcNow;

                    await _ticketService.UpdateTicketAsync(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id).Result)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.DeveloperUserId);
            ViewData["TicketStatusId"] = new SelectList(await _ticketService.GetTicketStatusesAsync(), "Id", "Name", ticket.TicketStatusId);
            ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name", ticket.TicketPriorityId);
            ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Archive/5
        [Authorize(Roles = "Admin, Project Manager")]
        public async Task<IActionResult> Archive()
        {
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId)).Where(t=>t.Archived == true || t.ArchivedByProject == true).ToList();
            return View(tickets);
        }

        // POST: Tickets/Archive/5
        [HttpPost, ActionName("Archive")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveConfirmed(int? ticketId)
        {
            if (ticketId == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Ticket ticket = await _ticketService.GetTicketByIdAsync(ticketId.Value, companyId);

            if (ticket != null)
            {
                await _ticketService.ArchiveTicketAsync(ticket);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Tickets/Restore/5
        [HttpPost, ActionName("Restore")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int? ticketId)
        {
            if (ticketId == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            Ticket ticket = await _ticketService.GetTicketByIdAsync(ticketId.Value, companyId);

            if (ticket != null)
            {
                await _ticketService.RestoreTicketAsync(ticket);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TicketExists(int id)
        {
            int companyId = User.Identity!.GetCompanyId();
            return (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId)).Any(e => e.Id == id);
        }
    }
}
