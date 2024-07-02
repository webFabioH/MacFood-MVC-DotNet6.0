using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacFood.Models
{
    [Table("PurchaseCartItem")]
    public class PurchaseCartItem
    {
        public int PurchaseCartItemId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }

        [StringLength(200)]
        public string PurchaseCartId { get; set; }
    }
}
