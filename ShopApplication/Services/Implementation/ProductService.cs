using ShopApplication.Models;
using ShopApplication.Repository.Interfaces;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Implementation
{
    public class ProductService : AbstractService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(ProductViewModel model, string userId)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                PhotoLink = model.PhotoLink,
                Description = model.Description,
                UserId = userId
            };
            _productRepository.Create(product);
        }

        public void Update(Product product, ProductViewModel model)
        {
            product.Price = model.Price;
            product.Name = model.Name;
            product.Description = model.Description;
            product.PhotoLink = model.PhotoLink;
            _productRepository.Update(product);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public ProductViewModel CreateProductViewModel(Product product)
        {
            var productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                Price = product.Price,
                Description = product.Description,
                Name = product.Name,
                PhotoLink = product.PhotoLink,
                UserName = product.User.UserName,
            };
            return productViewModel;
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(int startPosition, int count)
        {
            return await _productRepository.GetItemsAsync(startPosition, count);
        }

        public async Task<int> ItemsTotal()
        {
            return await _productRepository.CountAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
