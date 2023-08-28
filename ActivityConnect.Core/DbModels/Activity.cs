﻿using ActivityConnect.Core.Entities;

namespace ActivityConnect.Core.DbModels;

public class Activity : Entity<int>
{
    public int VenueId { get; set; }
    public int ActivityTypeId { get; set; }
    public int AuthorActivityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float TicketPrice { get; set; }
    public int TicketCapacity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
