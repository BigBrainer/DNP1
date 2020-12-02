using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace FamilyWebAPI.DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Adult> Adult { get; set; }
        public DbSet<Family> Family{ get; set; }
        public DbSet<User> User{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\School\Semester 3\DNP1\WebAPI\FamilyWebAPI\DataAccess\familyDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<Family>().HasKey(f => new { f.StreetName, f.HouseNumber });

            modelBuilder.Entity<ChildInterest>()
                .HasKey(ci =>
                    new
                    {
                        ci.ChildId,
                        ci.InterestId
                    });

            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Child)
                .WithMany(child => child.ChildInterests)
                .HasForeignKey(ci => ci.ChildId);

            modelBuilder.Entity<ChildInterest>()
                .HasOne(ci => ci.Interest)
                .WithMany(interest => interest.ChildInterests)
                .HasForeignKey(ci => ci.InterestId);

        }
    }
}
