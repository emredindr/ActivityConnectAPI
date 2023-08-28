using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
{
    public void Configure(EntityTypeBuilder<ActivityType> builder)
    {
        builder.HasKey(_activityType => _activityType.Id);

        builder.Property(_activityType => _activityType.Id)
            .HasColumnOrder(0);

        builder.Property(_activityType => _activityType.Name)
            .HasMaxLength(CoreConsts.MaxLength50)
            .IsRequired()
            .HasColumnOrder(1);

        builder.Property(_activityType => _activityType.Description)
            .HasMaxLength(CoreConsts.MaxLength200)
            .HasColumnOrder(2);

    }
}
