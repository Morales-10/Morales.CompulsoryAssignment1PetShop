using System;
using System.Collections.Generic;
using System.Linq;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.EntityFramework.Reositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDbContext _context;

        public InsuranceRepository(PetShopDbContext context)
        {
            _context = context;
        }
        
        public Insurance GetById(int id)
        {
           //Converter to insurance objekt
            return _context.Insurances
                .Select(ie => new Insurance
            {
                Id = ie.id,
                Name = ie.Name,
                Price = ie.Price
                
            }).FirstOrDefault(insurance => insurance.Id == id);
            
        }
    }
}