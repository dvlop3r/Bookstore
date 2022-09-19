using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models.Authentication;

namespace HelloWorld.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Register());
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register user)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Registration failed to complete!";
                return View(user);
            }
            var identity = new IdentityUser
            {
                Email = user.EmailAddress,
                UserName = user.Username
            };

            var result = await userManager.CreateAsync(identity, user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                ViewData["message"] = "Registration failed to complete!";
                return View(user);
            }
            TempData["message"] = "Account created successfully!";
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Authentication failure!";
                return View(login);
            }
            var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false);
            if (!result.Succeeded)
            {
                ViewData["message"] = "Authentication failure!";
                return View(login);
            }
            TempData["message"] = "Authentication succeeded!";
            if (returnUrl == null)
            {
                return RedirectToAction("index", "home");
            }
            return Redirect(returnUrl);
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            if (returnUrl == null)
                return RedirectToAction("index","home");
            return Redirect(returnUrl);
        }
    }
}