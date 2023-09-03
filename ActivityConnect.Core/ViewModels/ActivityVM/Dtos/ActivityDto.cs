using ActivityConnect.Core.ViewModels.ActivityTypeVM.Dtos;
using ActivityConnect.Core.ViewModels.AuthorActivityVM.Dtos;
using ActivityConnect.Core.ViewModels.Document.Dtos;

namespace ActivityConnect.Core.ViewModels.ActivityVM.Dtos;

public class ActivityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float TicketPrice { get; set; }
    public int TicketCapacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFavorite { get; set; }

    public ActivityTypeDto ActivityType { get; set; }
    public AuthorActivityDto AuthorInfo { get; set; }
    public List<DocumentDto> Images { get; set; }
}
