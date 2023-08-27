using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(_district => _district.Id);

        builder.Property(_district => _district.Id)
            .HasColumnOrder(0);

        builder.Property(_district => _district.Name).HasMaxLength(CoreConsts.MaxLength20).IsRequired();
    }
}
