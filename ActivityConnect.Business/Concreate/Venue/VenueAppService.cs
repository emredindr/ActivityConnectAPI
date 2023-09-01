using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.Venue;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Extensions.Linq;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.AddressVM.Dtos;
using ActivityConnect.Core.ViewModels.Document.Dtos;
using ActivityConnect.Core.ViewModels.VenueVM;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate;

public class VenueAppService : BaseAppService, IVenueAppService
{
    private readonly IRepository<Venue, int> _venueRepository;
    private readonly IRepository<Address, int> _addressRepository;
    private readonly IRepository<City, int> _cityRepository;
    private readonly IRepository<District, int> _districtRepository;
    private readonly IRepository<VenueDocument, int> _venueDocumentRepository;
    private readonly IRepository<Document, int> _documentRepository;


    public VenueAppService(IRepository<Venue, int> venueRepository, IRepository<Address, int> addressRepository, IRepository<District, int> districtRepository, IRepository<City, int> cityRepository, IRepository<Document, int> documentRepository, IRepository<VenueDocument, int> venueDocumentRepository)
    {
        _venueRepository = venueRepository;
        _addressRepository = addressRepository;
        _cityRepository = cityRepository;
        _districtRepository = districtRepository;
        _documentRepository = documentRepository;
        _venueDocumentRepository = venueDocumentRepository;
    }

    public async Task<ListResult<GetAllVenueInfo>> GetVenueList()
    {
        var query = from venue in _venueRepository.GetAll()
                    join address in _addressRepository.GetAll() on venue.AddressId equals address.Id
                    join city in _cityRepository.GetAll() on address.CityId equals city.Id
                    join district in _districtRepository.GetAll() on address.DistrictId equals district.Id
                    select new GetAllVenueInfo
                    {
                        Id = venue.Id,
                        Name = venue.Name,
                        SeatCapacity = venue.SeatCapacity,
                        PhoneNumber = venue.PhoneNumber,
                        Address = new AddressDto
                        {
                            Id = address.Id,
                            Latitude = address.Latitude,
                            Longitude = address.Longitude,
                            Name = address.Name,
                            OpenAddress = address.OpenAddress,
                            CityName = city.Name,
                            DistrictName = district.Name
                        },
                        Images = (from venueDocument in _venueDocumentRepository.GetAll()
                                  join document in _documentRepository.GetAll() on venueDocument.DocumentId equals document.Id
                                  where venueDocument.VenueId == venue.Id
                                  select new DocumentDto
                                  {
                                      Url = document.Url,
                                      Id = document.Id,
                                      ContentType = document.ContentType,
                                  }).ToList()
                    };

        var vanues = await query.ToListAsync();

        var mappedVenues = Mapper.Map<List<GetAllVenueInfo>>(vanues);

        return new ListResult<GetAllVenueInfo>(mappedVenues);
    }

    public async Task<ListResult<VenueDto>> GetVenueListByCityId(int cityId)
    {
        var query = from venue in _venueRepository.GetAll()
                    join address in _addressRepository.GetAll() on venue.AddressId equals address.Id
                    join city in _cityRepository.GetAll() on address.CityId equals city.Id
                    join district in _districtRepository.GetAll() on address.DistrictId equals district.Id
                    where cityId == city.Id
                    select new VenueDto
                    {
                        Id = venue.Id,
                        Name = venue.Name,
                        PhoneNumber = venue.PhoneNumber,
                        SeatCapacity = venue.SeatCapacity,
                        Address = new AddressDto
                        {
                            Id = address.Id,
                            Latitude = address.Latitude,
                            Longitude = address.Longitude,
                            Name = address.Name,
                            OpenAddress = address.OpenAddress,
                            CityName = city.Name,
                            DistrictName = district.Name
                        }
                    };
        var venues = await query.ToListAsync();

        return new ListResult<VenueDto>(venues);
    }


    [ValidationAspect(typeof(CreateVenueInputValidator))]
    public async Task CreateVenue(CreateVenueInput input)
    {
        var newAddress = Mapper.Map<Address>(input.Address);
        var addressId = await _addressRepository.InsertAndGetIdAsync(newAddress);

        var newVenue = Mapper.Map<Venue>(input);
        newVenue.AddressId = addressId;

        await _venueRepository.InsertAsync(newVenue);
    }
}