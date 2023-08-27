using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.HasKey(_venue => _venue.Id);

        builder.Property(_venue => _venue.Id)
            .HasColumnOrder(0);

        builder.Property(_venue => _venue.AddressId)
           .HasColumnOrder(1)
           .IsRequired();

        builder.Property(_venue => _venue.Name)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_venue => _venue.SeatCapacity)
          .HasColumnOrder(3)
          .IsRequired();

        builder.Property(_venue => _venue.PhoneNumber)
          .HasColumnOrder(4)
          .IsRequired();
    }
}
