using System.Collections.Generic;

namespace Morales.CompulsoryPetShop.EntityFramework.Entities
{
    public class InsuranceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public List<PetEntity> Pets { get; set; }
        
    }
}