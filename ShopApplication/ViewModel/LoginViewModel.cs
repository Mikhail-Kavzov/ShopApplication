using System.ComponentModel.DataAnnotations;

namespace ShopApplication.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
