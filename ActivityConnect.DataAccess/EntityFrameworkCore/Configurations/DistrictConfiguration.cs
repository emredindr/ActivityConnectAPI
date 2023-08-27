using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(_district => _district.Id);

        builder.Property(_district => _district.Id)
            .HasColumnOrder(0);

        builder.Property(_district => _district.CityId)
            .HasColumnOrder(1);

        builder.Property(_district => _district.Name).HasMaxLength(CoreConsts.MaxLength20).IsRequired();

    }
}
