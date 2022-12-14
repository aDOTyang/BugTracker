using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using BugTracker.Models.Enums;
using Microsoft.AspNetCore.DataProtection;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using BugTracker.Extensions;

namespace BugTracker.Controllers
{
    [Authorize(Roles =nameof(BTRoles.Admin))]
    public class InvitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectService _projectService;
        private readonly ICompanyService _companyService;
        private readonly IEmailSender _emailService;
        private readonly UserManager<BTUser> _userManager;
        private readonly IInviteService _inviteService;
        private readonly IDataProtector _protector;

        public InvitesController(ApplicationDbContext context, IProjectService projectService, IDataProtectionProvider dataProtectionProvider, ICompanyService companyService, IEmailSender emailService, UserManager<BTUser> userManager, IInviteService inviteService)
        {
            _context = context;
            _projectService = projectService;
            _companyService = companyService;
            _emailService = emailService;
            _userManager = userManager;
            _inviteService = inviteService;            
            // protector string used as hash for encryption
            _protector = dataProtectionProvider.CreateProtector("8ugM@g.22");
        }

        // GET: Invites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invites.Include(i => i.Company).Include(i => i.Invitee).Include(i => i.Invitor).Include(i => i.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invites == null)
            {
                return NotFound();
            }

            var invite = await _context.Invites
                .Include(i => i.Company)
                .Include(i => i.Invitee)
                .Include(i => i.Invitor)
                .Include(i => i.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invite == null)
            {
                return NotFound();
            }

            return View(invite);
        }

        [HttpGet]
        [AllowAnonymous]
        // GET: ProcessInvite
        public async Task<IActionResult> ProcessInvite(string token, string email, string company)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(company))
            {
                return NotFound();
            }

            Guid companyToken = Guid.Parse(_protector.Unprotect(token));
            string? inviteeEmail = _protector.Unprotect(email);
            int companyId = int.Parse(_protector.Unprotect(company));

            try
            {
                Invite? invite = await _inviteService.GetInviteAsync(companyToken, inviteeEmail, companyId);

                if (invite != null)
                {
                    return View(invite);
                }

                return NotFound();
            }
            catch (Exception) { throw; }
        }

        // GET: Invites/Create
        public async Task<IActionResult> Create()
        {
            int companyId = User.Identity!.GetCompanyId();

            // show name, but grab ID when selected
            ViewData["ProjectId"] = new SelectList(await _projectService.GetAllProjectsByCompanyIdAsync(companyId), "Id", "Name");
            return View();
        }

        // POST: Invites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,ProjectId,InvitorId,InviteeId,InviteeEmail,InviteeFirstName,InviteeLastName,Message,IsValid,InviteDate,JoinDate,CompanyToken")] Invite invite)
        {
            ModelState.Remove("InvitorId");
            int companyId = User.Identity!.GetCompanyId();

            if (ModelState.IsValid)
            {
                try
                {
                    //encrypt code for invite
                    Guid guid = Guid.NewGuid();

                    string token = _protector.Protect(guid.ToString());
                    string email = _protector.Protect(invite.InviteeEmail!);
                    string company = _protector.Protect(companyId.ToString());

                    string? callbackUrl = Url.Action("ProcessInvite", "Invites", new { token, email, company }, protocol: Request.Scheme);

                    string body = $@"{invite.Message} <br />
                       Please join my Company. <br />
                       Click the following link to join our team. <br />
                       <a href=""{callbackUrl}"">COLLABORATE</a>";

                    string? destination = invite.InviteeEmail;

                    Company btCompany = await _companyService.GetCompanyInfoAsync(companyId);

                    string? subject = $" Nova Tracker: {btCompany.Name} Invite";

                    await _emailService.SendEmailAsync(destination, subject, body);

                    // Save invite in the DB
                    invite.CompanyToken = guid;
                    invite.CompanyId = companyId;
                    invite.InviteDate = DateTime.UtcNow;
                    invite.InvitorId = _userManager.GetUserId(User);
                    invite.IsValid = true;

                    // Add Invite service method for "AddNewInviteAsync"
                    await _inviteService.AddNewInviteAsync(invite);

                    return RedirectToAction("Index", "Home");

                    // TODO: Possibly use SWAL message

                }
                catch (Exception) { throw; }
            }

            ViewData["ProjectId"] = new SelectList(await _projectService.GetAllProjectsByCompanyIdAsync(companyId), "Id", "Name");
            return View(invite);
        }

        private bool InviteExists(int id)
        {
          return _context.Invites.Any(e => e.Id == id);
        }
    }
}
