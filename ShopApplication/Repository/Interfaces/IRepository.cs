using ShopApplication.Models;

namespace ShopApplication.Repository.Interfaces
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }
}
