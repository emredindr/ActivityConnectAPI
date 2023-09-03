using ActivityConnect.Core.ViewModels.ActivityVM.Dtos;
using ActivityConnect.Core.ViewModels.AddressVM.Dtos;
using ActivityConnect.Core.ViewModels.Document.Dtos;

namespace ActivityConnect.Core.ViewModels.ActivityVM;

public class GetAllVenueActivityInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SeatCapacity { get; set; }
    public string PhoneNumber { get; set; }

    public AddressDto Address { get; set; }
    public List<DocumentDto> Images { get; set; }
    public List<ActivityDto> Activities { get; set; }

}
