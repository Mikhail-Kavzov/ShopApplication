using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IProductService : IService
    {
        void Create(ProductViewModel model, string userId);
        Task<Product?> GetProductById(int id);
        Task<int> ItemsTotal();
        ProductViewModel CreateProductViewModel(Product product);
        Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count);
        void Update(Product product, ProductViewModel model);
        Task DeleteAsync(Product product);
    }
}
