using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(_address => _address.Id);

        builder.Property(_address => _address.Id)
            .HasColumnOrder(0);

        builder.Property(_address => _address.CityId)
           .HasColumnOrder(1)
           .IsRequired();

        builder.Property(_address => _address.DistrictId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_address => _address.OpenAddress)
          .HasColumnOrder(3)
          .IsRequired();

        builder.Property(_address => _address.Latitude)
          .HasColumnOrder(4)
          .IsRequired();

        builder.Property(_address => _address.Longitude)
          .HasColumnOrder(5)
          .IsRequired();
    }
}
