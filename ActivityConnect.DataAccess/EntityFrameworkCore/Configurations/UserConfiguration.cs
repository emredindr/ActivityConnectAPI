using ActivityConnect.Core.Constants;
using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(b => b.Surname).HasMaxLength(CoreConsts.MaxLength50);
            builder.Property(b => b.UserName).HasMaxLength(CoreConsts.MaxLength50);
            builder.Property(b => b.Email).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(b => b.Password).HasMaxLength(CoreConsts.MaxLength50);
        }
    }
}