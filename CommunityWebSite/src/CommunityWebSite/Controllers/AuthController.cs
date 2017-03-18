using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models;
using Microsoft.AspNetCore.Identity;
using CommunityWebSite.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers {
    public class AuthController : Controller {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AuthController(UserManager<User> usrMgr, SignInManager<User> sim, RoleManager<IdentityRole> rolemngr) {
            userManager = usrMgr;
            signInManager = sim;
            roleManager = rolemngr;
        }

        public IActionResult Register() {
            return View(new RegisterViewModel());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminRegister() {
            var adminVM = new AdminRegisterViewModel();

            adminVM.Roles = new List<string> {
                "Member",
                "Admin"
            };

            return View(adminVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminRegister(AdminRegisterViewModel vm) {
            if (ModelState.IsValid) {
                User user = new User {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);
                string role = vm.Role;
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    if (result.Succeeded) {
                        await userManager.AddToRoleAsync(user, role);
                        if (result.Succeeded) {
                            return RedirectToAction("Index", "Home");
                        }
                    } else {
                        foreach (IdentityError error in result.Errors) {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                } else {
                    await userManager.AddToRoleAsync(user, role);
                    if (result.Succeeded) {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(vm);
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
                string role = "Member";
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    if (result.Succeeded) {
                        await userManager.AddToRoleAsync(user, role);
                        if (result.Succeeded) {
                            return RedirectToAction("Index", "Home");
                        }
                    } else {
                        foreach (IdentityError error in result.Errors) {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                } else {
                    await userManager.AddToRoleAsync(user, role);
                    if(result.Succeeded) {
                        return RedirectToAction("Index", "Home");
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
