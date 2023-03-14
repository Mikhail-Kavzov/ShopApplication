using ShopApplication.Models;
using ShopApplication.Repository.Interfaces;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Implementation
{
    public class ProductService : AbstractService, IProductService
    {
        public ProductService(IProductRepository productRepository) :base(productRepository)
        {
        }

        public void Create(ProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                PhotoLink = model.PhotoLink,
                Description = model.Description,
                UserId = 
            };
        }
    }
}
