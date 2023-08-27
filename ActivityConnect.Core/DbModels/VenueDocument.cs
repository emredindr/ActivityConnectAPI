using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class VenueDocument:Entity<int>
{
    public int VenueId { get; set; }
    public int DocumentId { get; set; }

}
