using ActivityConnect.Core.ViewModels.AddressVM.Dtos;

namespace ActivityConnect.Core.ViewModels.VenueVM;

public class GetAllVenueInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SeatCapacity { get; set; }
    public string PhoneNumber { get; set; }

    public AddressDto Address { get; set; }
}
