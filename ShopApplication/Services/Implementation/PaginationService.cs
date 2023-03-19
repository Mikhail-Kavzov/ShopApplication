using ShopApplication.Models;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;

namespace ShopApplication.Services.Implementation
{
    public class PaginationService : IPaginationService
    {
        public IndexViewModel<T> CreateIndexViewModel<T>(int page, int count, int pagesCount,
            IEnumerable<T> items) where T : class
        {
            PageInfoViewModel pageInfo = new()
            {
                PageNumber = page,
                PageSize = pagesCount,
                TotalItems = count,
            };
            var indexModel = new IndexViewModel<T>
            {
                Items = items,
                PageInfo = pageInfo,
            };
            return indexModel;
        }
    }
}
