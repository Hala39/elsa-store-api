namespace ELSAPI.Helpers
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 11;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        
        public int? CategoryId { get; set; }
        public int? SizeId { get; set; }
        public string SearchString { get; set; }
        public string OrderBy {get; set; }
        
        
    }
}