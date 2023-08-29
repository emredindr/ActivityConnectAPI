using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
{
    public void Configure(EntityTypeBuilder<UserActivity> builder)
    {
        builder.HasKey(_seat => _seat.Id);

        builder.Property(_seat => _seat.UserId)
            .HasColumnOrder(0);

        builder.Property(_seat => _seat.ActivityId)
            .HasColumnOrder(1);

        builder.Property(_seat => _seat.SeatId)
            .HasColumnOrder(2);

        builder.Property(_seat => _seat.CreationTime)
            .HasColumnOrder(3);
    }
}
