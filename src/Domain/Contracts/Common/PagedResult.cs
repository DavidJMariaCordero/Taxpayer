using Microsoft.EntityFrameworkCore;

namespace Domain.Contracts.Common
{

    public class PagedResult<T> : List<T>
    {

        public PageMetaData MetaData { get; set; }


        public PagedResult()
        {
        }

        public PagedResult(IReadOnlyCollection<T> data, int totalItems, int pageNumber, int itemsPerPage)
        {
            MetaData = new PageMetaData()
            {
                CurrentPage = pageNumber,
                ItemsPerPage = itemsPerPage,
                PageCount = (int)Math.Ceiling(totalItems / (double)itemsPerPage),
                TotalItems = totalItems,
                CurrentPageItems = data.Count
            };

            AddRange(data);
        }


        public static async Task<PagedResult<T>> ToPagedResult(IQueryable<T> data, int pageNumber, int itemsPerPage)
        {
            var totalItems = data.Count();

            var items = await data
                .Skip((pageNumber - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return new PagedResult<T>(items, totalItems, pageNumber, itemsPerPage);
        }
    }
}