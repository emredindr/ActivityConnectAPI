using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class AuthorActivityConfiguration : IEntityTypeConfiguration<AuthorActivity>
{
    public void Configure(EntityTypeBuilder<AuthorActivity> builder)
    {
        builder.HasKey(_authorActivityType => _authorActivityType.Id);

        builder.Property(_authorActivityType => _authorActivityType.Id)
            .HasColumnOrder(0);

        builder.Property(_authorActivityType => _authorActivityType.Author)
            .HasMaxLength(CoreConsts.MaxLength100)
            .HasColumnOrder(1);

        builder.Property(_authorActivityType => _authorActivityType.Translator)
            .HasMaxLength(CoreConsts.MaxLength100)
            .HasColumnOrder(2);

        builder.Property(_authorActivityType => _authorActivityType.DirectedBy)
            .HasMaxLength(CoreConsts.MaxLength100)
            .HasColumnOrder(3);
    }
}
