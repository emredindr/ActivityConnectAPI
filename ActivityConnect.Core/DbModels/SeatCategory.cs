using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class SeatCategory : Entity<int>
{
    public string Name { get; set; }
    public float SeatPrice { get; set; }
}
