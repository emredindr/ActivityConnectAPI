using ActivityConnect.Core.ViewModels.ActivityTypeVM.Dtos;
using ActivityConnect.Core.ViewModels.AuthorActivityVM.Dtos;
using ActivityConnect.Core.ViewModels.Document.Dtos;
using ActivityConnect.Core.ViewModels.VenueVM.Dtos;

namespace ActivityConnect.Core.ViewModels.ActivityVM;

public class GetAllActivityInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float TicketPrice { get; set; }
    public int TicketCapacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ActivityTypeDto ActivityType { get; set; }
    public VenueDto Venue { get; set; }
    public AuthorActivityDto AuthorInfo { get; set; }
    public List<DocumentDto> Images { get; set; }
}
