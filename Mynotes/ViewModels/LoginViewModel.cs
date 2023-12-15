
using System.ComponentModel.DataAnnotations;

namespace Mynotes.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
