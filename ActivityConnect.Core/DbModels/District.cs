using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class District:Entity<int>
{
    public string Name { get; set; }
    public int CityId { get; set;}
}
