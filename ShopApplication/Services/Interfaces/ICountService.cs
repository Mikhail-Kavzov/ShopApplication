namespace ShopApplication.Services.Interfaces
{
    public interface ICountService : IService
    {
        Task<int> ItemsTotal();
    }
}
