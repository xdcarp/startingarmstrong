namespace Armstrong.Common.Paging
{
    /// <summary>
    /// The result class for a paginated list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResult<T> : PagingResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagingResult()
        {
            Results = new List<T>();
        }

        public PagingResult(IList<T> results, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Results = results;
        }
    }
}
