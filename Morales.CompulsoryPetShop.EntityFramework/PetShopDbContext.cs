using Microsoft.EntityFrameworkCore;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.EntityFramework.Entities;

namespace Morales.CompulsoryPetShop.EntityFramework
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {id = 1, Name = "Buzz", Price = 10});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {id = 2, Name = "Woody", Price = 23});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {id = 3, Name = "Rex", Price = 42});
        }
        public DbSet<InsuranceEntity> Insurances { get; set; }
    }
}