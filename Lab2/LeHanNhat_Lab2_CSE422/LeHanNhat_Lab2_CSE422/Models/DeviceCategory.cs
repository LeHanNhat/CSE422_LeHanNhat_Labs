using System.ComponentModel.DataAnnotations;

namespace LeHanNhat_Lab2_CSE422.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s-]+$", ErrorMessage = "Name can only contain letters, numbers, spaces and hyphens")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
