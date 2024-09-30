using System.ComponentModel.DataAnnotations.Schema;

namespace MacFood.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }    
        public int FoodId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
