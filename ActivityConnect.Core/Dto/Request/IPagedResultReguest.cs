namespace ActivityConnect.Core.Dto.Request
{
    public interface IPagedResultReguest : ILimitedResultRequest
    {
        int SkipCount { get; set; }
    }
}
