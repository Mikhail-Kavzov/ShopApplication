using ShopApplication.Models;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Interfaces
{
    public interface IPaginationService
    {
        public IndexViewModel<T> CreateIndexViewModel<T>(int page, int count, int pagesCount,
            IEnumerable<T> items) where T : class;
    }
}
