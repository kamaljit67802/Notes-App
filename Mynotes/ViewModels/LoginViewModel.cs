using System.ComponentModel.DataAnnotations;

namespace Mynotes.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
