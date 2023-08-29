using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(_seat => _seat.Id);

        builder.Property(_seat => _seat.Id)
            .HasColumnOrder(0);

        builder.Property(_seat => _seat.CategoryId)
            .HasColumnOrder(1);

        builder.Property(_seat => _seat.Name)
            .HasMaxLength(CoreConsts.MaxLength50)
            .HasColumnOrder(2);

        
    }
}
