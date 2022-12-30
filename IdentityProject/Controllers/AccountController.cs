using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
               // user.Email = model.Email;
                user.UserName = model.Username;
                //user.EmailConfirmed = true;

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Email confirmation token
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    return RedirectToAction("index", "home");
                }
            }
            return View(model);
        }
    }
}
