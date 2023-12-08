// Mynotes.Models.Category.cs

using System.ComponentModel.DataAnnotations;

namespace Mynotes.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(50, ErrorMessage = "Category Name cannot exceed 50 characters")]
        public string? Name { get; set; }
    }
}