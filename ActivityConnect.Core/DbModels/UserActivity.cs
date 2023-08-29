using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class UserActivity:Entity<int>
{
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    public int SeatId { get; set; }
    public DateTime CreationTime { get; set; }

}
