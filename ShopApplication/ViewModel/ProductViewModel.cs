namespace ShopApplication.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public int Price { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? PhotoLink { get; set; }
    }
}
