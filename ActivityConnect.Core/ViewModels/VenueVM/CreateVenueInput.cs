using ActivityConnect.Core.ViewModels.AddressVM;

namespace ActivityConnect.Core.ViewModels.VenueVM;

public class CreateVenueInput
{
    public string Name { get; set; }
    //public int AddressId { get; set; }
    public int SeatCapacity { get; set; }
    public string PhoneNumber { get; set; }

    public CreateAddressInput Address { get; set; }
}
