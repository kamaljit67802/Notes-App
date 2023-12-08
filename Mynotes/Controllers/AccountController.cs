// Mynotes.Controllers.AccountController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Mynotes.Models; 
using Mynotes.ViewModels;

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
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
    }
}
