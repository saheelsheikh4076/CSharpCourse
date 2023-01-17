﻿using IdentityProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace IdentityProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly EmailService emailService;

        public AccountController(UserManager<IdentityUser> userManager,
            EmailService emailService, SignInManager<IdentityUser> _signinManager, RoleManager<IdentityRole> roleManager)
        {
            this.signinManager = _signinManager;
            this.userManager = userManager;
            this.emailService = emailService;
            this.roleManager = roleManager;
        }
        //[Authorize]//Only logged in user can access/enter
        //[Authorize(Policy = "AdminPolicy")]//Only AdminPolicy validated user can access
        //[Authorize(Roles="Admin")]//Only user with Admin role can access
        [Authorize(Roles="Admin,Teacher")]//only user with either Admin or Teacher can access
        public async Task<IActionResult> Roles()
        {
            var user = await userManager.GetUserAsync(User);
            var isInRole = await userManager.IsInRoleAsync(user, "Admin");
            if (!isInRole)
            {
               var result = await userManager.AddToRoleAsync(user, "Admin");
            }
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        //[Route("/Account/UserProfile")]
        [HttpGet]
     
        public async Task<IActionResult> Profile(string id)
        {
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                //user not found
                return View("Error");
            }
            var userRoles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            var availableRoles = roleManager.Roles;
            List<AppUserRoles> appUserRoles = new List<AppUserRoles>();
            foreach (var role in availableRoles)
            {
                var isAssigned = userRoles.Where(s => s == role.Name).Any();
                appUserRoles.Add(new AppUserRoles
                {
                    RoleId = role.Id,
                    UserId = id,
                    RoleName = role.Name,
                    IsAssigned = isAssigned
                });
            }
            ProfileViewModel model = new ProfileViewModel();
            model.Username = user.UserName;
            model.Email = user.Email;
           // model.Roles = roleManager.Roles.Select(s => new AppRoles { Id = s.Id, RoleName = s.Name }).ToList();
            model.UserRoles = appUserRoles;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoles(ProfileViewModel model)
        {
            var userId = model.UserRoles.Select(s => s.UserId).FirstOrDefault();
            var user = await userManager.FindByIdAsync(userId).ConfigureAwait(false);
            var assignedRoleListOld = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            var assignedRoleListNew = model.UserRoles.Where(s=>s.IsAssigned).Select(s => s.RoleName);
            var result = await userManager.RemoveFromRolesAsync(user, assignedRoleListOld).ConfigureAwait(false);
            if (result.Succeeded)
            {
                result = await userManager.AddToRolesAsync(user, assignedRoleListNew).ConfigureAwait(false);
                if (result.Succeeded)
                {
                   // signinManager.SignInAsync(user, false,);

                    return RedirectToAction("Profile", new {id = userId});
                }
                //Add error that failed to update roles
                return View("Error");
            }
            //error add (failed to update roles)
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string RoleName)
        {
            var newRole = new IdentityRole(RoleName);
            var result = await roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Roles));
            }
            //add error message that failed to add new role
            return View("Error");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Users()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                //add all errors in loop
                return View("Error");

            }
            //add error that user not found
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                foreach (var item in result.Errors)
                {
                    //add all errors 
                }
                //redirect to error page and pass all errors
                return View("Error");
            }
            //add error that role not found
            return View("Error");
        }

        [Authorize]//This will allow only logged in users to access this action
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
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
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}