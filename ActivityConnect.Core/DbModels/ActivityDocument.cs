using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class ActivityDocument :Entity<int>
{
    public int ActivityId { get; set; }
    public int DocumentId { get; set; }
    public bool IsDefault { get; set; }
}
