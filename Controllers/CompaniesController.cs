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
using Microsoft.AspNetCore.Authorization;
using BugTracker.Models.ViewModels;
using BugTracker.Extensions;
using BugTracker.Services.Interfaces;
using BugTracker.Models.Enums;

namespace BugTracker.Controllers
{
    [Authorize(Roles = nameof(BTRoles.Admin))]
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;
        private readonly ICompanyService _companyService;
        private readonly IRolesService _rolesService;

        public CompaniesController(ApplicationDbContext context, UserManager<BTUser> userManager, ICompanyService companyService, IRolesService rolesService)
        {
            _context = context;
            _userManager = userManager;
            _companyService = companyService;
            _rolesService = rolesService;
        }

        // GET: Companies
        //public async Task<IActionResult> Index()
        //{
        //    int companyId = (await _userManager.GetUserAsync(User)).CompanyId;
        //    return View(await _context.Companies.Where(c=>c.Id == companyId).ToListAsync());
        //}

        [HttpGet]
        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        /// <summary>
        /// creates lists of users and roles for assignation, excluding current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            List<ManageUserRolesViewModel> model = new();
            int companyId = User.Identity!.GetCompanyId();
            List<BTUser> members = await _companyService.GetMembersAsync(companyId);
            string btUserId = _userManager.GetUserId(User);

            foreach (BTUser member in members)
            {
                if (string.Compare(btUserId, member.Id) != 0)
                {
                    ManageUserRolesViewModel viewModel = new();
                    IEnumerable<string> currentRoles = await _rolesService.GetUserRolesAsync(member);
                    viewModel.BTUser = member;
                    viewModel.Roles = new MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", currentRoles);
                    model.Add(viewModel);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel viewModel)
        {
            int companyId = User.Identity!.GetCompanyId();
            BTUser? btUser = (await _companyService.GetMembersAsync(companyId)).FirstOrDefault(c => c.Id == viewModel.BTUser!.Id);
            IEnumerable<string> currentRoles = await _rolesService.GetUserRolesAsync(btUser!);
            string? selectedRole = viewModel.SelectedRoles!.FirstOrDefault();

            if (!string.IsNullOrEmpty(selectedRole))
            {
                if (await _rolesService.RemoveUserFromRolesAsync(btUser!, currentRoles))
                {
                    await _rolesService.AddUserToRoleAsync(btUser!, selectedRole);
                }
            }

            return RedirectToAction(nameof(ManageUserRoles));
        }
    }
}
