using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class Venue : Entity<int>
{
    public string Name { get; set; }
    public int AddressId { get; set; }
    public int SeatCapacity { get; set; }
    public string PhoneNumber { get; set; }
}
