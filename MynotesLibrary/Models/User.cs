// Mynotes.Models.User.cs

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic; // Add this using directive
using System.ComponentModel.DataAnnotations;

namespace Mynotes.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public List<Note>? Notes { get; set; } // Move this property inside the class
    }
}
