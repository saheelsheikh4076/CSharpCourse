using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
