using System.ComponentModel.DataAnnotations;

namespace Mynotes.ViewModels
{
    public class LoginViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
