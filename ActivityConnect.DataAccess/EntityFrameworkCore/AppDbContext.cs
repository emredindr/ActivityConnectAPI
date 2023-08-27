using ActivityConnect.Core.DbModels;
using ActivityConnect.DataAccess.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ActivityConnect.DataAccess.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new  AddressConfiguration());
            modelBuilder.ApplyConfiguration(new  CityConfiguration());
            modelBuilder.ApplyConfiguration(new  DistrictConfiguration());
        }
    }
}
