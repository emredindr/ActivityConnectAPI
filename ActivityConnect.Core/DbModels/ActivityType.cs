using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class ActivityType:Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
