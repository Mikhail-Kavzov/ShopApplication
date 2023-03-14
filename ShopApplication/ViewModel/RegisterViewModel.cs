using System.ComponentModel.DataAnnotations;

namespace ShopApplication.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Field is empty")]
        [StringLength(15, ErrorMessage = "Name should contain 1..15 symbols")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(20, ErrorMessage = "Email should contain 1..20 symbols")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(20, ErrorMessage = "Password should contain 1..20 symbols")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
