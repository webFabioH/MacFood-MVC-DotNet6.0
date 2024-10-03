using System.ComponentModel.DataAnnotations;

namespace MacFood.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Type your name")]
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Type your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
