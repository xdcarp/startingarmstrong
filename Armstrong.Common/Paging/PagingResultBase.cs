namespace Armstrong.Common.Paging
{
    /// <summary>
    /// Result object that will be used in our paginated list
    /// </summary>
    public class PagingResultBase
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int RowCount { get; set; }

        public int TotalPages { get; set; }

        public int FirstRowOnPage => (PageIndex - 1) * PageSize + 1;

        public int LastRowOnPage => Math.Min(PageIndex * PageSize, RowCount);

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < PageCount;
    }
}
