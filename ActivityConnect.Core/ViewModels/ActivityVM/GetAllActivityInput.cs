namespace ActivityConnect.Core.ViewModels.ActivityVM;

public class GetAllActivityInput
{
    public int? VenueId { get; set; }
    public int? ActivityTypeId { get; set; }
    public int? CityId { get; set; }
    public DateTime? StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
}
