namespace ActivityConnect.Core.Dto.Response
{
    [Serializable]
    public class ListResult<T> : IListResult<T> where T : class
    {
        private IReadOnlyList<T> _data;
        public ListResult()
        {

        }
        public ListResult(IReadOnlyList<T> data)
        {
            Data = data;
        }
        public IReadOnlyList<T> Data
        {
            get
            {
                return _data ?? (_data = new List<T>());
            }
            set
            {
                _data = value;
            }
        }
    }
}
