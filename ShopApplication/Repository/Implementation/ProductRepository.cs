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
            return await _context.Products.Include(p => p.User)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count,
            string sortOrder = "", string filter = "")
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(p => p.Name.Contains(filter,
                    StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        {
                            query = query.OrderByDescending(p => p.Name);
                            break;
                        }
                    case "price":
                        {
                            query = query.OrderBy(p => p.Price);
                            break;
                        }
                    case "price_desc":
                        {
                            query = query.OrderByDescending(p => p.Price);
                            break;
                        }
                    default:
                        {
                            query = query.OrderBy(p => p.Name);
                            break;
                        }
                }
            }
            query = query.Skip(startPosition).Take(count);
            return await query.ToListAsync();
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
