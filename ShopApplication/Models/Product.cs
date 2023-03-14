namespace ShopApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int Price { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhotoLink { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public User? User { get; set; }
    }
}
