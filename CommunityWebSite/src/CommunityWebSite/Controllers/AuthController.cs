using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models;
using Microsoft.AspNetCore.Identity;
using CommunityWebSite.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers {
    public class AuthController : Controller {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AuthController(UserManager<User> usrMgr, SignInManager<User> sim) {
            userManager = usrMgr;
            signInManager = sim;
        }

        public IActionResult Register() {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm) {
            if (ModelState.IsValid) {
                User user = new User {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded) {
                   // await userManager.AddToRoleAsync(user, "Members");
                    if (result.Succeeded) {
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    foreach (IdentityError error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // We get here either if the model state is invalid or if create user fails
            return View(vm);
        }

        public ViewResult Login(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl) {
            if (ModelState.IsValid) {
                User user = await userManager.FindByNameAsync(vm.UserName);
                if (user != null) {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, vm.Password, false, false);
                    if (result.Succeeded) {
                        // return to the action that required authorization, or to home if returnUrl is null
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName),
                    "Invalid user or password");
            }
            return View(vm);
        }

        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
