using ActivityConnect.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityConnect.DataAccess.EntityFrameworkCore.Configurations
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermission");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
