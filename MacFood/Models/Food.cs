namespace MacFood.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string DetailedDescription { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        public string ImageThubnailUrl { get; set; } = string.Empty; 

        public bool IsFavoriteFood { get; set; }  
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 
    }
}
