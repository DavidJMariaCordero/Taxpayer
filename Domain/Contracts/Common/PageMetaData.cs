namespace Domain.Contracts.Common
{
    /// <summary>
    /// Paging Metadata Class
    /// </summary>
    public class PageMetaData
    {
        /// <summary>Max number of elements returned per page (if exists)</summary>
        public int ItemsPerPage { get; set; }

        /// <summary>Total number of elements existing in the collection (if any)</summary>
        public int TotalItems { get; set; }

        /// <summary>Number of the current page returned</summary>
        public int CurrentPage { get; set; }

        /// <summary>Number of elements found and returned for the current page</summary>
        public int CurrentPageItems { get; set; }

        /// <summary>Total number of pages found, given the <see cref="TotalItems"/> and the <see cref="ItemsPerPage"/></summary>
        public int PageCount { get; set; }

        /// <summary>Is the <see cref="CurrentPage"/> the first page?</summary>
        public bool IsFirstPage => CurrentPage <= 1;

        /// <summary>Is the <see cref="CurrentPage"/> the last page?</summary>
        public bool IsLastPage => CurrentPage == PageCount;

        /// <summary>Is there a next page?</summary>
        public bool HasNextPage => CurrentPage < PageCount;

        /// <summary>Is there a previous page?</summary>
        public bool HasPreviousPage => CurrentPage > 1;
    }
}