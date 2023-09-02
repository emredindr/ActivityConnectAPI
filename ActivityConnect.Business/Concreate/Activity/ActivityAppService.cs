using ActivityConnect.Business.Abstract;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Extensions.ResponseAndExceptionMiddleware;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.ActivityTypeVM.Dtos;
using ActivityConnect.Core.ViewModels.ActivityVM;
using ActivityConnect.Core.ViewModels.AddressVM.Dtos;
using ActivityConnect.Core.ViewModels.AuthorActivityVM.Dtos;
using ActivityConnect.Core.ViewModels.Document.Dtos;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate;

public class ActivityAppService : BaseAppService, IActivityAppService
{
    private readonly IRepository<Activity, int> _activityRepository;
    private readonly IRepository<AuthorActivity, int> _authorActivityRepository;
    private readonly IRepository<ActivityType, int> _activityTypeRepository;
    private readonly IRepository<Venue, int> _venueRepository;
    private readonly IRepository<Address, int> _addressRepository;
    private readonly IRepository<City, int> _cityRepository;
    private readonly IRepository<District, int> _districtRepository;
    private readonly IRepository<ActivityDocument, int> _activityDocumentRepository;
    private readonly IRepository<Document, int> _documentRepository;



    public ActivityAppService(IRepository<ActivityType, int> activityTypeRepository, IRepository<AuthorActivity, int> authorActivityRepository, IRepository<Activity, int> activityRepository, IRepository<Venue, int> venueRepository, IRepository<Address, int> addressRepository, IRepository<City, int> cityRepository, IRepository<District, int> districtRepository, IRepository<ActivityDocument, int> activityDocumentRepository, IRepository<Document, int> documentRepository)
    {
        _activityTypeRepository = activityTypeRepository;
        _authorActivityRepository = authorActivityRepository;
        _activityRepository = activityRepository;
        _venueRepository = venueRepository;
        _addressRepository = addressRepository;
        _cityRepository = cityRepository;
        _districtRepository = districtRepository;
        _activityDocumentRepository = activityDocumentRepository;
        _documentRepository = documentRepository;
    }

    public async Task<ListResult<GetAllActivityInfo>> GetActivityList()
    {
        var query = from activity in _activityRepository.GetAll()
                    select new GetAllActivityInfo
                    {
                        Name = activity.Name,
                        Description = activity.Description,
                        TicketPrice = activity.TicketPrice,
                        TicketCapacity = activity.TicketCapacity,
                        StartDate = activity.StartDate,
                        EndDate = activity.EndDate,

                        Venue = (from venue in _venueRepository.GetAll()
                                 where venue.Id == activity.VenueId
                                 select new VenueDto
                                 {
                                     Name = venue.Name,
                                     Id = venue.Id,
                                     SeatCapacity = venue.SeatCapacity,
                                     PhoneNumber = venue.PhoneNumber,
                                     Address = (from address in _addressRepository.GetAll()
                                                join city in _cityRepository.GetAll() on address.CityId equals city.Id
                                                join district in _districtRepository.GetAll() on address.DistrictId equals district.Id
                                                where venue.AddressId == address.Id
                                                select new AddressDto
                                                {
                                                    Id = address.Id,
                                                    CityName = city.Name,
                                                    DistrictName = district.Name,
                                                    Latitude = address.Latitude,
                                                    Longitude = address.Longitude,
                                                    Name = address.Name,
                                                    OpenAddress = address.OpenAddress
                                                }
                                              ).FirstOrDefault()
                                 }).FirstOrDefault(),

                        AuthorInfo = (from authorActivity in _authorActivityRepository.GetAll()
                                      where authorActivity.Id == activity.AuthorActivityId
                                      select new AuthorActivityDto
                                      {
                                          Id = authorActivity.Id,
                                          Author = authorActivity.Author,
                                          Translator = authorActivity.Translator,
                                          DirectedBy = authorActivity.DirectedBy
                                      }).FirstOrDefault(),

                        ActivityType = (from activityType in _activityTypeRepository.GetAll()
                                        where activityType.Id == activity.ActivityTypeId
                                        select new ActivityTypeDto
                                        {
                                            Id = activityType.Id,
                                            Name = activityType.Name,
                                            Description = activityType.Description,
                                        }).FirstOrDefault(),

                        Images = (from activityDocument in _activityDocumentRepository.GetAll()
                                  join document in _documentRepository.GetAll() on activityDocument.DocumentId equals document.Id
                                  where activityDocument.ActivityId == activity.Id
                                  select new DocumentDto
                                  {
                                      Id = document.Id,
                                      Url = document.Url,
                                      ContentType = document.ContentType,
                                  }).ToList()
                    };

        var activities = await query.ToListAsync();

        var mappedActivities = Mapper.Map<List<GetAllActivityInfo>>(activities);

        return new ListResult<GetAllActivityInfo>(activities);
    }

    public async Task CreateActivity(CreateActivityInput input)
    {
        var newAuthorActivity = Mapper.Map<AuthorActivity>(input.AuthorActivity);

        var newActivity = Mapper.Map<Activity>(input);

        var AuthorActivity = await _authorActivityRepository.FirstOrDefaultAsync(x => x.Author == newAuthorActivity.Author);

        if (AuthorActivity == null)
        {
           var _authorActivityId = await _authorActivityRepository.InsertAndGetIdAsync(newAuthorActivity);

            if (_authorActivityId == null)
            {
                throw new ApiException("Author oluşturulurken hata oldu !");
            }
            newActivity.AuthorActivityId = _authorActivityId;

        }

        newActivity.AuthorActivityId = AuthorActivity.Id;



        newActivity.EndDate = newActivity.StartDate.AddHours(3);

        await _activityRepository.InsertAsync(newActivity);
    }

}
