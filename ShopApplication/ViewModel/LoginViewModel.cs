using System.ComponentModel.DataAnnotations;

namespace ShopApplication.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field is empty")]
        [StringLength(20, ErrorMessage = "Email should contain 1..20 symbols")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(20, ErrorMessage = "Password should contain 1..20 symbols")]
        public string? Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
