using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<User?> GetUserById(string id);
        Task<int> ItemsTotal();
        Task<IEnumerable<User>> GetItemsAsync(int startPosition, int count);
    }
}
