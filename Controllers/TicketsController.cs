using System;
using System.IO;
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
using BugTracker.Models.ViewModels;
using System.Net.Sockets;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly UserManager<BTUser> _userManager;
        private readonly ITicketService _ticketService;
        private readonly IProjectService _projectService;
        private readonly IRolesService _rolesService;
        private readonly ITicketHistoryService _historyService;
        private readonly IFileService _fileService;

        public TicketsController(UserManager<BTUser> userManager, ITicketService ticketService, IProjectService projectService, IRolesService rolesService, ITicketHistoryService historyService, IFileService fileService)
        {
            _userManager = userManager;
            _ticketService = ticketService;
            _projectService = projectService;
            _rolesService = rolesService;
            _historyService = historyService;
            _fileService = fileService;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            //int companyId = (await _userManager.GetUserAsync(User)).CompanyId;
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId)).Where(c => c.Archived == false && c.ArchivedByProject == false).ToList();
            return View(tickets);
        }

        /// <summary>
        /// returns filtered list of assigned tickets
        /// </summary>
        /// <returns></returns>
        // GET: Tickets
        public async Task<IActionResult> MyTickets()
        {
            //int companyId = (await _userManager.GetUserAsync(User)).CompanyId;
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetTicketsByUserIdAsync((await _userManager.GetUserAsync(User)).Id, companyId)).ToList();
            return View(tickets);
        }

        // GET: Tickets/Unassigned
        public async Task<IActionResult> Unassigned()
        {
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId)).Where(c => c.Archived == false && c.ArchivedByProject == false)
                                                        .Where(c => c.DeveloperUserId == null).ToList();
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

        [HttpGet]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        // GET: Projects/AssignDev
        public async Task<IActionResult> AssignDev(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int companyId = User.Identity!.GetCompanyId();
            List<BTUser> developers = await _rolesService.GetUsersInRoleAsync(nameof(BTRoles.Developer), User.Identity!.GetCompanyId());
            BTUser? currentDev = await _ticketService.GetDeveloperAsync(id.Value, companyId);


            AssignDevViewModel viewModel = new()
            {
                Ticket = await _ticketService.GetTicketByIdAsync(id.Value, companyId),
                //Project = await _projectService.GetProjectByIdAsync(id.Value, User.Identity!.GetCompanyId()),
                DevList = new SelectList(developers, "Id", "FullName", currentDev?.Id),
                DevId = currentDev?.Id
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = nameof(BTRoles.Admin))]
        [ValidateAntiForgeryToken]
        // POST: Projects/AssignDev
        public async Task<IActionResult> AssignDev(AssignDevViewModel viewModel)
        {
            if (viewModel.Ticket?.Id != null)
            {
                int companyId = User.Identity!.GetCompanyId();
                string userId = _userManager.GetUserId(User);
                Ticket oldTicket = await _ticketService.GetTicketAsNoTrackingAsync(viewModel.Ticket.Id, companyId);

                if (!string.IsNullOrEmpty(viewModel.DevId))
                {
                    await _ticketService.AddDeveloperToTicketAsync(viewModel.DevId, viewModel.Ticket.Id, companyId);
                }
                Ticket newTicket = await _ticketService.GetTicketAsNoTrackingAsync(viewModel.Ticket.Id, companyId);
                newTicket.TicketStatusId = (await _ticketService.GetTicketStatusesAsync()).FirstOrDefault(t => t.Name == nameof(BTTicketStatuses.Development))!.Id;
                await _historyService.AddHistoryAsync(oldTicket!, newTicket, userId);
                return RedirectToAction(nameof(Details), new { ticketId = viewModel.Ticket?.Id });
            }
            return View(viewModel);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProjectId"] = new SelectList(await _projectService.GetUserProjectsAsync((await _userManager.GetUserAsync(User)).Id), "Id", "Name");
            ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name");
            ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name");
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

                //add History Record
                int companyId = User.Identity!.GetCompanyId();
                Ticket newTicket = await _ticketService.GetTicketAsNoTrackingAsync(ticket.Id, companyId);
                await _historyService.AddHistoryAsync(null!, newTicket, ticket.SubmitterUserId);

                return RedirectToAction(nameof(Index));
            }

            //ViewData["DeveloperUser"] = new SelectList(_context.Users, "Id", "Name", ticket.DeveloperUser!.FullName);
            ViewData["ProjectId"] = new SelectList(await _projectService.GetUserProjectsAsync((await _userManager.GetUserAsync(User)).Id), "Id", "Name");
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

            //string userId = _userManager.GetUserId(User);
            int companyId = User.Identity!.GetCompanyId();

            // TODO: compare ticket to user for submitter/developer/PM

            if (User.IsInRole(nameof(BTRoles.Admin)))
            {
                Ticket? ticket = await _ticketService.GetTicketByIdAsync(ticketId.Value, companyId);

                if (ticket == null)
                {
                    return NotFound();
                }

                ViewData["DeveloperUser"] = new SelectList(await _ticketService.GetDevelopersByCompanyAsync(companyId), "Id", "FullName", ticket.DeveloperUser);
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

            int companyId = User.Identity!.GetCompanyId();
            string userId = _userManager.GetUserId(User);
            Ticket oldTicket = await _ticketService.GetTicketAsNoTrackingAsync(ticket.Id, companyId);

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.Created = DateTime.SpecifyKind(ticket.Created, DateTimeKind.Utc);
                    ticket.Updated = DateTime.UtcNow;

                    if (ticket.DeveloperUserId != null && ticket.TicketStatus!.Name == nameof(BTTicketStatuses.New))
                    {
                        ticket.TicketStatusId = (await _ticketService.GetTicketStatusesAsync()).FirstOrDefault(t => t.Name == nameof(BTTicketStatuses.Development))!.Id;
                    }

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
                Ticket newTicket = await _ticketService.GetTicketAsNoTrackingAsync(ticket.Id, companyId);
                await _historyService.AddHistoryAsync(oldTicket!, newTicket, userId);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperUser"] = new SelectList(await _ticketService.GetDevelopersByCompanyAsync(companyId), "Id", "FullName", ticket.DeveloperUser);
            ViewData["TicketStatusId"] = new SelectList(await _ticketService.GetTicketStatusesAsync(), "Id", "Name", ticket.TicketStatusId);
            ViewData["TicketPriorityId"] = new SelectList(await _ticketService.GetTicketPrioritiesAsync(), "Id", "Name", ticket.TicketPriorityId);
            ViewData["TicketTypeId"] = new SelectList(await _ticketService.GetTicketTypesAsync(), "Id", "Name", ticket.TicketTypeId);
            return View(ticket);
        }

        // POST: Tickets/AddTicketAttachment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTicketAttachment([Bind("Id,FormFile,Description,TicketId")] TicketAttachment ticketAttachment, int ticketId)
        {
            string statusMessage;
            ModelState.Remove("UserId");
            ModelState.Remove("FormFile");

            if (ModelState.IsValid && ticketAttachment.FormFile != null)
            {
                ticketAttachment.FileData = await _fileService.ConvertFileToByteArrayAsync(ticketAttachment.FormFile);
                ticketAttachment.FileName = ticketAttachment.FormFile.FileName;
                ticketAttachment.FileContentType = ticketAttachment.FormFile.ContentType;
                ticketAttachment.Created = DateTime.UtcNow;
                ticketAttachment.UserId = _userManager.GetUserId(User);

                // add to context and save changes only
                await _ticketService.AddTicketAttachmentAsync(ticketAttachment);
                statusMessage = "Success: New attachment added to Ticket.";
            }
            else
            {
                statusMessage = "Error: Invalid data.";

            }

            return RedirectToAction("Details","Tickets", new { ticketId = ticketAttachment.TicketId, message = statusMessage });
        }

        public async Task<IActionResult> ShowFile(int id)
        {
            TicketAttachment ticketAttachment = await _ticketService.GetTicketAttachmentByIdAsync(id);
            string fileName = ticketAttachment.FileName!;
            byte[] fileData = ticketAttachment.FileData!;
            string ext = Path.GetExtension(fileName)!.Replace(".", "");

            Response.Headers.Add("Content-Disposition", $"inline; filename={fileName}");
            return File(fileData, $"application/{ext}");
        }

        // GET: Tickets/Archive/5
        [Authorize(Roles = $"{nameof(BTRoles.Admin)}, {nameof(BTRoles.ProjectManager)}")]
        public async Task<IActionResult> Archive()
        {
            int companyId = User.Identity!.GetCompanyId();
            List<Ticket> tickets = (await _ticketService.GetAllTicketsByCompanyIdAsync(companyId)).Where(t => t.Archived == true || t.ArchivedByProject == true).ToList();
            return View(tickets);
        }

        // POST: Tickets/Archive/5
        [HttpPost, ActionName("Archive")]
        [Authorize(Roles = nameof(BTRoles.Admin))]
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
        [Authorize(Roles = nameof(BTRoles.Admin))]
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
