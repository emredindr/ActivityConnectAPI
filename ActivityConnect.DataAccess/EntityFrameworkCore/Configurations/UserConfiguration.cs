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
            builder.HasKey(_user => _user.Id);

            builder.Property(_user => _user.Id).HasColumnOrder(0);

            builder.Property(_user => _user.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired().HasColumnOrder(1);

            builder.Property(_user => _user.Surname).HasMaxLength(CoreConsts.MaxLength50).HasColumnOrder(2);

            builder.Property(_user => _user.UserName).HasMaxLength(CoreConsts.MaxLength50).HasColumnOrder(3);

            builder.Property(_user => _user.Email).HasMaxLength(CoreConsts.MaxLength50).IsRequired().HasColumnOrder(4);

            builder.Property(_user => _user.Password).HasMaxLength(CoreConsts.MaxLength50).HasColumnOrder(5);
            
            builder.Property(_user => _user.Gender).HasMaxLength(CoreConsts.MaxLength10).HasColumnOrder(6);

            builder.Property(_user => _user.Birthdate).HasColumnOrder(7);

            builder.Property(_user => _user.PhoneNumber).HasColumnOrder(8);


        }
    }
}