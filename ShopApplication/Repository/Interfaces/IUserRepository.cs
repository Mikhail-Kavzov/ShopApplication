using ShopApplication.Models;

namespace ShopApplication.Repository.Interfaces
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        Task<User?> GetUserById(string id);
    }
}
