using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var callBackUrl1 = Url.Action("ConfirmEmail", "Account",
                new { test1 = "hello", test2 = "world" },Request.Scheme);
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var users = userManager.Users;
            foreach (var item in users)
            {
                await userManager.DeleteAsync(item);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}