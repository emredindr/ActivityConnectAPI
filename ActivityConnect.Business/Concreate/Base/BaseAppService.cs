using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.Mappings.AutoMapper;
using AutoMapper;

namespace ActivityConnect.Business.Concreate
{
    public abstract class BaseAppService : IBaseAppService
    {
        public IMapper Mapper
        {
            get
            {
                return ObjectMapper.Mapper;
            }
        }
    }
}
