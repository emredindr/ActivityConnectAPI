using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(_activity => _activity.Id);

        builder.Property(_activity => _activity.Id)
         .HasColumnOrder(0);

        builder.Property(_activity => _activity.VenueId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_activity => _activity.ActivityTypeId)
           .HasColumnOrder(2)
           .IsRequired();

        builder.Property(_activity => _activity.AuthorActivityId)
           .HasColumnOrder(3);

        builder.Property(_activity => _activity.Name)
            .HasMaxLength(CoreConsts.MaxLength100)
            .IsRequired()
            .HasColumnOrder(4);

        builder.Property(_activity => _activity.Description)
            .HasMaxLength(CoreConsts.MaxLength500)
            .HasColumnOrder(5);

        builder.Property(_activity => _activity.TicketPrice)
            .HasColumnOrder(6);

        builder.Property(_activity => _activity.TicketCapacity)
           .HasColumnOrder(7);

        builder.Property(_activity => _activity.StartDate)
           .HasColumnOrder(8);
        
        builder.Property(_activity => _activity.EndDate)
           .HasColumnOrder(9);

        builder.Property(_activity => _activity.IsFavorite)
            .HasDefaultValue(false)
           .HasColumnOrder(10);
    }
}
