using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class Seat : Entity<int>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
}