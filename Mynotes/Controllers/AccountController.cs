using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Mynotes.Models;
using Mynotes.ViewModels;
using System.Threading.Tasks;

namespace Mynotes.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.Email))
                {
                    ModelState.AddModelError(nameof(model.Email), "Email is required.");
                    return View(model);
                }

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Index), "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
                {
                    ModelState.AddModelError(string.Empty, "Username and password are required.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

                if (result.RequiresTwoFactor)
                {
                    // Handle two-factor authentication, if needed
                    // You may add code here if you have two-factor authentication
                    return RedirectToAction(nameof(Index), "Home"); // Example redirection
                }

                if (result.IsLockedOut)
                {
                    // Handle account lockout, if needed
                    // You may add code here to handle lockout
                    return RedirectToAction(nameof(Index), "Home"); // Example redirection
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
