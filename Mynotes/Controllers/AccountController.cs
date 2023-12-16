// AccountController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Mynotes.Models;
using Mynotes.ViewModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Mynotes.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            _logger.LogInformation("Registration attempt.");

            if (ModelState.IsValid)
            {
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
                    _logger.LogInformation($"User {user.UserName} registered successfully.");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Index), "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    _logger.LogError($"Error during registration: {error.Description}");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login page requested.");
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("Login attempt.");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user,
                        model.Password,
                        model.RememberMe,
                        lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"User {user.UserName} logged in successfully.");
                        return RedirectToAction(nameof(Index), "Home");
                    }

                    if (result.RequiresTwoFactor)
                    {
                        _logger.LogInformation("Two-factor authentication is required.");
                        return RedirectToAction(nameof(Index), "Home");
                    }

                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account is locked out.");
                        return RedirectToAction(nameof(Index), "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                _logger.LogError("Invalid login attempt.");
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logout attempt.");

            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Note");
        }
    }
}
