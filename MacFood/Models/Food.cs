using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacFood.Models
{
    [Table("Foods")]
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "The food's name must be provided")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "MinLength = 10 | MaxLength = 80")]
        [Display(Name = "Food's name")]
        public string FoodName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description must be provided")]
        [Display(Name = "Food's description")]
        [MinLength(20, ErrorMessage = "MinLength = 20")]
        [MaxLength(200, ErrorMessage = "MaxLength = 200")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "The detailed description must be provided")]
        [Display(Name = "Food's detailed description")]
        [MinLength(20, ErrorMessage = "MinLength = 20")]
        [MaxLength(200, ErrorMessage = "MaxLength = 200")]
        public string DetailedDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the value of the food")]
        [Display(Name = "Value")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "The values range is between 1.0 and 999.99")]
        public decimal Value { get; set; }

        [Display(Name = "Normal image path")]
        [StringLength(200, ErrorMessage = "MaxLength = 200")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Thumbnail image path")]
        [StringLength(200, ErrorMessage = "MaxLength = 200")]
        public string ImageThumbnailUrl { get; set; } = string.Empty;

        [Display(Name = "Favorite?")]
        public bool IsFavoriteFood { get; set; }

        [Display(Name = "Stock")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 
    }
}
