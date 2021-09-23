using Microsoft.EntityFrameworkCore;
using Morales.CompulsoryPetShop.EntityFramework.Entities;

namespace Morales.CompulsoryPetShop.EntityFramework
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Insurance)
                .WithMany();
            
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 1, Name = "Woody", Price = 34});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 2, Name = "Buzz", Price = 42});
            modelBuilder.Entity<InsuranceEntity>().HasData(new InsuranceEntity {Id = 3, Name = "Rex", Price = 24});
        }
        
        public DbSet<PetEntity> Pet { get; set; }
        public DbSet<InsuranceEntity> Insurances { get; set;}
     
    }
}