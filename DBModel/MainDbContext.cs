using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel
{
    public class MainDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("00000000-0000-0000-8000-000000000001"),
                    Birthday = new DateTime(2019, 11, 25),
                    FirstName = "Петр",
                    Surname = "Иванов",
                    Email = "test@test.com",
                    Address = "Test address",
                    DateUpdated = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder
            //        .UseLoggerFactory(loggerFactory);
            //}
        }

    }
}
