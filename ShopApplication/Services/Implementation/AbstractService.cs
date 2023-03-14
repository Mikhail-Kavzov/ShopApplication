using ShopApplication.Repository.Interfaces;
using ShopApplication.Services.Interfaces;

namespace ShopApplication.Services.Implementation
{
    public abstract class AbstractService : IService
    {
        protected readonly IRepository _repository;

        protected AbstractService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveTableAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
