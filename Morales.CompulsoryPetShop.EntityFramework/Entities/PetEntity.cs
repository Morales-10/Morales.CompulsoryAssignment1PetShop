using System;

namespace Morales.CompulsoryPetShop.EntityFramework.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public int InsuranceId { get; set; }
        public InsuranceEntity Insurance { get; set; }

        public int OwnerId { get; set; }
        
    }
}