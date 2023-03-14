namespace ShopApplication.Repository.Interfaces
{
    public interface ICRUDRepository<T>:IRepository
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        Task<IEnumerable<T>> GetItemsAsync(int startPosition, int count);
        Task<int> CountAsync();
    }
}
