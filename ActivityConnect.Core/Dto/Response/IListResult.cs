namespace ActivityConnect.Core.Dto.Response
{
    public interface IListResult<T> where T : class
    {
        IReadOnlyList<T> Data { get; set; }

    }
}
