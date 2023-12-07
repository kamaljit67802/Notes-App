using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 
using Mynotes.Models; 

namespace Mynotes.Controllers 
{ 
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        // Constructor
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Create an instance of RegisterViewModel
            var model = new RegisterViewModel();

            // Pass the model to the view
            return View(model);
        }
    }
}
