using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(CoreConsts.MaxLength200);
    }
}
