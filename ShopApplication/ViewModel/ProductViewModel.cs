using System.ComponentModel.DataAnnotations;

namespace ShopApplication.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(15, ErrorMessage = "Name should contain 1..15 symbols")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Field is empty")]
        [StringLength(300, ErrorMessage = "Description should contain 1..300 symbols")]
        public string Description { get; set; } = null!;

        public string? PhotoLink { get; set; }

        public string? UserName { get; set; }
    }
}
