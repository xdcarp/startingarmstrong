using Armstrong.Common.Paging;
using Microsoft.EntityFrameworkCore;

namespace Armstrong.Application.Extensions
{
    /// <summary>
    /// Extensions of IQueryable
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Generates a paginated list based on an IQueryable source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PagingResult<T>> CreatePagingListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize) where T : class
        { 
            var count = await source.CountAsync();
            var results = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagingResult<T>(results, count, pageIndex, pageSize);
        }
    }
}
