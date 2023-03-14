using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IProductService : IService
    {
        void Create(ProductViewModel model, string userId);
        Task<Product?> GetProductById(int id);
        ProductViewModel CreateProductViewModel(Product product);
        void Update(Product product, ProductViewModel model);
        Task<IEnumerable<Product>> GetProductsAsync(int startPosition, int count);
        Task<int> ProductsTotal();
    }
}
