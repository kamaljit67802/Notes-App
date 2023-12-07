namespace MyNotes.ViewModels
{
    public class LoginViewModel
    {  
        [Required]
        public string? UserName { get; set;}
        [Required]
        public string? Password { get; set;}
        [Display ("Remember Me")]
        public bool RememberMe { get; set; }
    }
}