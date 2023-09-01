using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.ActivityTypeVM;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate;

public class ActivityTypeAppService : BaseAppService, IActivityTypeAppService
{
    private readonly IRepository<ActivityType, int> _activityTypeRepository;

    public ActivityTypeAppService(IRepository<ActivityType, int> activityTypeRepository)
    {
        _activityTypeRepository = activityTypeRepository;
    }

    public async Task<ListResult<GetAllActivityTypeInfo>> GetActivityTypeList()
    {
        var activityTypes =await _activityTypeRepository.GetAll().ToListAsync();

        var mappedActivityTypes = Mapper.Map<List<GetAllActivityTypeInfo>>(activityTypes);

        return new ListResult<GetAllActivityTypeInfo>(mappedActivityTypes);
    }
}
