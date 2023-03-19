using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IUserService : ICountService
    {
        Task<User?> GetUserById(string id);
        Task<IEnumerable<User>> GetItemsAsync(int startPosition, int count);
    }
}
