namespace ActivityConnect.Core.Dto.Response
{
    [Serializable]
    public class PagedResult<T> : ListResult<T>, IPagedResult<T> where T : class
    {
        public int TotalCount { get; set; }
        public PagedResult()
        {

        }
        public PagedResult(int totalCount, IReadOnlyList<T> data) : base(data)
        {
            TotalCount = totalCount;
        }
    }
}
