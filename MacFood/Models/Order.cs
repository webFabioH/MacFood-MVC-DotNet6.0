using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacFood.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Type name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Type your adress")]
        [StringLength(100)]
        public string Adress { get; set; }

        [StringLength(100)]
        [Display(Name = "Complement")]
        public string Adress2 { get; set; }

        [Required(ErrorMessage = "Type your adress")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        [StringLength (10)]
        public string State { get; set; }

        [StringLength (50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Type your phone number")]
        [StringLength (25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required (ErrorMessage = "Type your email")]
        [StringLength (50)]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Total order")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Order itens")]
        public int OrderTotalItens {  get; set; }

        [Display(Name = "Order date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? SendOrder {  get; set; }

        [Display(Name = "Order date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveredOrderIn { get; set; }

        public List<OrderDetails> OrderItens { get; set; }
    }
}
