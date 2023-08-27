using ActivityConnect.Business.Abstract;
using ActivityConnect.Business.ValidationRules.FluentValidation.Venue;
using ActivityConnect.Core.Aspects.AutoFac.Validation;
using ActivityConnect.Core.DbModels;
using ActivityConnect.Core.Dto.Response;
using ActivityConnect.Core.Repositories;
using ActivityConnect.Core.ViewModels.AddressVM.Dtos;
using ActivityConnect.Core.ViewModels.VenueVM;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.Business.Concreate;

public class VenueAppService : BaseAppService, IVenueAppService
{
    private readonly IRepository<Venue, int> _venueRepository;
    private readonly IRepository<Address, int> _addressRepository;
    private readonly IRepository<City, int> _cityRepository;
    private readonly IRepository<District, int> _districtRepository;

    public VenueAppService(IRepository<Venue, int> venueRepository, IRepository<Address, int> addressRepository, IRepository<District, int> districtRepository, IRepository<City, int> cityRepository)
    {
        _venueRepository = venueRepository;
        _addressRepository = addressRepository;
        _cityRepository = cityRepository;
        _districtRepository = districtRepository;
    }

    public async Task<ListResult<GetAllVenueInfo>> GetVenueList()
    {
        var query = from vanue in _venueRepository.GetAll()
                    join address in _addressRepository.GetAll() on vanue.AddressId equals address.Id
                    join city in _cityRepository.GetAll() on address.CityId equals city.Id
                    join district in _districtRepository.GetAll() on city.Id equals district.CityId
                    select new GetAllVenueInfo
                    {
                        Id = vanue.Id,
                        Name = vanue.Name,
                        SeatCapacity = vanue.SeatCapacity,
                        PhoneNumber = vanue.PhoneNumber,
                        Address = new AddressDto
                        {
                            Id = address.Id,
                            Latitude = address.Latitude,
                            Longitude = address.Longitude,
                            Name = address.Name,
                            OpenAddress = address.OpenAddress,
                            CityName = city.Name,
                            DistrictName= district.Name
                        }
                    };

        var vanues = await query.ToListAsync();

        var mappedVenues = Mapper.Map<List<GetAllVenueInfo>>(vanues);

        return new ListResult<GetAllVenueInfo>(mappedVenues);
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