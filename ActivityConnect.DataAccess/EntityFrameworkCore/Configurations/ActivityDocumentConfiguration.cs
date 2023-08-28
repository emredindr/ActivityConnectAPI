using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class ActivityDocumentConfiguration : IEntityTypeConfiguration<ActivityDocument>
{
    public void Configure(EntityTypeBuilder<ActivityDocument> builder)
    {
        builder.HasKey(_venueDocument => _venueDocument.Id);

        builder.Property(_activityDocument => _activityDocument.Id)
            .HasColumnOrder(0);

        builder.Property(_activityDocument => _activityDocument.ActivityId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_activityDocument => _activityDocument.DocumentId)
            .HasColumnOrder(2)
            .IsRequired();
    }
}
