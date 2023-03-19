using System.ComponentModel.DataAnnotations;

namespace ShopApplication.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field is empty")]
        [StringLength(15, ErrorMessage = "Name should contain 1..15 symbols")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(20, ErrorMessage = "Password should contain 1..20 symbols")]
        public string? Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
