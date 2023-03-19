using ShopApplication.Models;

namespace ShopApplication.Repository.Interfaces
{
    public interface IProductRepository:ICRUDRepository<Product>
    {
       Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count,
            string sortOrder = "", string filter = "");
    }
}
