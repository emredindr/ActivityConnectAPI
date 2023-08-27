using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class City : Entity<int>
{
    public string Name { get; set; }
}
