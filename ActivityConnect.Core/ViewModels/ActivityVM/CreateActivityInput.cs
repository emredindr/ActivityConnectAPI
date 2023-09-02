using ActivityConnect.Core.ViewModels.AuthorActivityVM;

namespace ActivityConnect.Core.ViewModels.ActivityVM;

public class CreateActivityInput
{
    public int VenueId { get; set; }
    public int ActivityTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float TicketPrice { get; set; }
    public int TicketCapacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public CreateAuthorActivityInput AuthorActivity { get; set; }
}
