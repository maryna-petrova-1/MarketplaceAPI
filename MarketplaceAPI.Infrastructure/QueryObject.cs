using System;
namespace MarketplaceAPI.Infrastructure
{
    public class QueryObject
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Seller { get; set; }

        public bool IsSortAscending { get; set; }

        public string SortBy { get; set; }

        public int Page { get; set; } = 1;

        const int maxPageSize = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}

