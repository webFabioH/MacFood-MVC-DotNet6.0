using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacFood.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length - 100 characters")]
        [Required(ErrorMessage = "Enter the category name")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Maximum length - 100 characters")]
        [Required(ErrorMessage = "Enter the description of the category")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        public List<Food> Food { get; set; }
    }
}
