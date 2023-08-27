using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class VenueDocumentConfiguration : IEntityTypeConfiguration<VenueDocument>
{
    public void Configure(EntityTypeBuilder<VenueDocument> builder)
    {
        builder.HasKey(_venueDocument => _venueDocument.Id);

        builder.Property(_venueDocument => _venueDocument.Id)
            .HasColumnOrder(0);

        builder.Property(_venueDocument => _venueDocument.VenueId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_venueDocument => _venueDocument.DocumentId)
            .HasColumnOrder(2)
            .IsRequired();

    }
}
