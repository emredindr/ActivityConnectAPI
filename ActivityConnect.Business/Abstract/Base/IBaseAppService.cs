using AutoMapper;

namespace ActivityConnect.Business.Abstract
{
    public interface IBaseAppService
    {
        IMapper Mapper { get; }
    }
}
