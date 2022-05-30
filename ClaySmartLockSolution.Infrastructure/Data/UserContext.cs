using ClaySmartLockSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Infrastructure.Data
{

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {
        }
        public DbSet<Core.Entities.User> Users
        {
            get;
            set;
        }

        public DbSet<Core.Entities.Door> Doors
        {
            get;
            set;
        }

        public DbSet<Core.Entities.UserDoorAccess> UserDoorAccesses
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("UserDB");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Door>().HasData(
                new Door
                {
                    DoorId = 1,
                    DoorLocation = "Office Door",
                },
                  new Door
                  {
                      DoorId = 2,
                      DoorLocation = "Tunnel",
                  }
            );
            modelBuilder.Entity<User>().Property(b => b.DateOfCreation).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>().Property(b => b.DoorAccessTag).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserDoorAccess>().Property(b => b.AccessDate).HasDefaultValueSql("getdate()");
        }
    }
}
