﻿using ActivityConnect.Core.DbModels;
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
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<VenueDocument> VenueDocuments { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<AuthorActivity> AuthorActivities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ActivityDocument> ActivityDocuments { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatCategory> SeatCategories { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new VenueConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new VenueDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new UserActivityConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new SeatCategoryConfiguration());

        }
    }
}
