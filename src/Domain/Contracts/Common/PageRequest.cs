
namespace Domain.Contracts.Common
{
    /// <summary>
    /// Helper class to request data in a paged-result mode
    /// </summary>
    public class PageRequest
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        /// <summary>Number of page requested</summary>
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }

        /// <summary>Max number of items per page requested</summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 50) ? 50 : value;
        }
    }
}