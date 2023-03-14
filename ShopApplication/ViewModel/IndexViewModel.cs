namespace ShopApplication.ViewModel
{
    public class IndexViewModel<T> where T : class
    {
        public PageInfoViewModel PageInfo { get; set; } = null!;
        public IEnumerable<T> Items { get; set; } = null!;
    }
}
