using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IProductService : ICountService
    {
        void Create(ProductViewModel model, string userId);
        Task<Product?> GetProductById(int id);
        ProductViewModel CreateProductViewModel(Product product);
        Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count,
            string sortOrder = "", string filter = "");
        void Update(Product product, ProductViewModel model);
        Task DeleteAsync(Product product);
    }
}
