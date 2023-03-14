using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IProductService : IService
    {
        void Create(ProductViewModel model);
    }
}
