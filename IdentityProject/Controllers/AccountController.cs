using IdentityProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace IdentityProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;
        private readonly EmailService emailService;

        public AccountController(UserManager<IdentityUser> userManager, 
            EmailService emailService, SignInManager<IdentityUser> _signinManager)
        {
            this.signinManager = _signinManager;
            this.userManager = userManager;
            this.emailService = emailService;
        }
        [Authorize]//This will allow only logged in users to access this action
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found, try again");
                }                
            }
            return View(model);
        }
        public async Task<IActionResult> PasswordReset(string userId, string token)
        {
            PasswordResetViewModel model = new PasswordResetViewModel
            {
                UserId = userId,
                Token = token
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordReset(PasswordResetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        await signinManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    var errorMessage = string.Empty;
                    foreach (var item in result.Errors)
                    {
                        errorMessage += item.Description + " | ";
                    }
                    AppResultStatus errorModel = new AppResultStatus()
                    {
                        IsSuccess = false,
                        ErrorCode = 2000,
                        ErrorMessage = errorMessage
                    };
                    return View("Error", errorModel);
                }
                await signinManager.SignInAsync(user,false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                AppResultStatus errorModel1 = new AppResultStatus()
                {
                    IsSuccess = false,
                    ErrorCode = 2001,
                    ErrorMessage = "user not found"
                };
                return View("Error", errorModel1);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var user = await userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var callBackUrl = Url.Action("PasswordReset", "Account",
                         new { userId = user.Id, token }, Request.Scheme);

                    var encodedUrl = HtmlEncoder.Default.Encode(callBackUrl);
                    var messageBody = $"<p>Confirm your account by clicking <a href='{encodedUrl}'>here</a></p>";
                    emailService.SendEmail(new EmailData
                    {
                        EmailToId = user.Email,
                        EmailToName = user.UserName,
                        EmailSubject = "Password Reset Link",
                        EmailBody = messageBody
                    });
                    return RedirectToAction("index", "home");
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)//create a LoginViewModel class and add properties, username and password and boolean remember me
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                   var signInResult = await signinManager.PasswordSignInAsync(user, model.Password,isPersistent: model.Remember, false);
                    if (signInResult.Succeeded)
                    {
                        if (string.IsNullOrEmpty(model.ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return LocalRedirect(model.ReturnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "username or password is incorrect");
                        
                    }
                }
                else
                {
                    //username does not exist
                    ModelState.AddModelError("", "Username does not exist");
                }
            }
            return View(model);
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
                user.Email = model.Email;
                user.UserName = model.Username;
                //user.EmailConfirmed = true;

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Email confirmation token
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callBackUrl = Url.Action("ConfirmEmail", "Account",
                         new { userId = user.Id, token }, Request.Scheme);
                   
                    var encodedUrl = HtmlEncoder.Default.Encode(callBackUrl);
                    var messageBody = $"<p>Confirm your account by clicking <a href='{encodedUrl}'>here</a></p>";
                    emailService.SendEmail(new EmailData
                    {
                        EmailToId = model.Email,
                        EmailToName = model.Username,
                        EmailSubject = "Account verfication",
                        EmailBody = messageBody
                    });
                    return RedirectToAction("index", "home");
                }
            }
            return View(model);
        }
    }
}
