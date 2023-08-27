using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class Address : Entity<int>
{
    public string Name { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string OpenAddress { get; set; }
}
