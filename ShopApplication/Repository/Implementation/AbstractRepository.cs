using ShopApplication.Context;
using ShopApplication.Repository.Interfaces;

namespace ShopApplication.Repository.Implementation
{
    public abstract class AbstractRepository:IRepository
    {
        protected readonly ApplicationContext _context;

        protected AbstractRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
