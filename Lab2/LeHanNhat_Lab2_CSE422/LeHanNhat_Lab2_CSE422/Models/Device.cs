using System.ComponentModel.DataAnnotations;

namespace LeHanNhat_Lab2_CSE422.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Device Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Device code is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Code must be between 3 and 20 characters")]
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "Code can only contain uppercase letters, numbers and hyphens")]
        [Display(Name = "Device Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Device Status")]
        public DeviceStatus Status { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}
