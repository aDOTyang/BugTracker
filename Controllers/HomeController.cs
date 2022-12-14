using BugTracker.Extensions;
using BugTracker.Models;
using BugTracker.Models.ViewModels;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketService _ticketService;
        private readonly IProjectService _projectService;
        private readonly UserManager<BTUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ITicketService ticketService, IProjectService projectService, UserManager<BTUser> userManager)
        {
            _logger = logger;
            _ticketService = ticketService;
            _projectService = projectService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if ((User.Identity?.IsAuthenticated)!.Value)
            {
                int companyId = User.Identity!.GetCompanyId();
                string userId = _userManager.GetUserId(User);

                HomeDashboardViewModel viewModel = new()
                {
                    Projects = (await _projectService.GetUserProjectsAsync(userId))!.ToList(),
                    Tickets = (await _ticketService.GetTicketsByUserIdAsync(userId, companyId)).ToList()
                };
                return View(viewModel);
            }
            return View();
            //return RedirectToAction("EmptyIndex");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}