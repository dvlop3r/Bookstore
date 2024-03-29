﻿using Bookstore.Client.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Client.Controllers
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
        public async Task<IActionResult> Register(Register user, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Account registration failure!";
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
                ViewData["message"] = "Account registration failure!";
                return View(user);
            }
            TempData["message"] = "Account created successfully!";
            return Redirect(returnUrl);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login, string returnUrl)
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
            return Redirect(returnUrl);
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }
    }
}