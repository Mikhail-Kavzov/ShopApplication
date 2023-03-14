using Microsoft.EntityFrameworkCore;
using ShopApplication.Context;
using ShopApplication.Models;
using ShopApplication.Repository.Interfaces;

namespace ShopApplication.Repository.Implementation
{
    public class ProductRepository : AbstractRepository, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(Product item)
        {
            _context.Products.Remove(item);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p=>p.User)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count)
        {
            return await _context.Products.Include(p => p.User)
                .Skip(startPosition).Take(count).ToListAsync();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
