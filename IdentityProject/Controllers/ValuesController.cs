using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
   // [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public ValuesController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Test()
        {
            var obj = new
            {
                name= "irfan",
                subject = "c#"
            };
            return Json(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromQuery]string username, [FromQuery] string password,[FromHeader] string Token)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        isAuthenticated = true,
                        username = username
                    });
                }
                return BadRequest(new
                {
                    isAuthenticated = false,
                    username = username,
                    reason = "Username or Password incorrect"
                });
            }
            return BadRequest(new
            {
                isAuthenticated = false,
                username = username,
                reason = "User not found"
            });
        }
    }
}
