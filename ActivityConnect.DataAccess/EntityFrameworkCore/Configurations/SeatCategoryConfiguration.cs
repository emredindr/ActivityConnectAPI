using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class SeatCategoryConfiguration : IEntityTypeConfiguration<SeatCategory>
{
    public void Configure(EntityTypeBuilder<SeatCategory> builder)
    {
        builder.HasKey(_seatCategory => _seatCategory.Id);

        builder.Property(_seatCategory => _seatCategory.Id)
            .HasColumnOrder(0);

        builder.Property(_seatCategory => _seatCategory.Name)
            .HasMaxLength(CoreConsts.MaxLength50)
            .HasColumnOrder(1);

        builder.Property(_seatCategory => _seatCategory.SeatPrice)
            .HasColumnOrder(2);
    }
}
