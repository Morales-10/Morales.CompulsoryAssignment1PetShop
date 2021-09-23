using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;
using Morales.CompulsoryPetShop.EntityFramework.Entities;

namespace Morales.CompulsoryPetShop.EntityFramework.Repositories
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
            return _context.Insurances
                .Select(ie => new Insurance
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

        public Insurance Create(Insurance insurance)
        {
            var entity = _context.Add(new InsuranceEntity()
            {
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _context.SaveChanges();
            return new Insurance()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public List<Insurance> GetAll()
        {
            return _context.Insurances.Select(insurance => new Insurance
                {
                    Id = insurance.Id,
                    Name = insurance.Name,
                    Price = insurance.Price
                })
                .Take(50)
                .OrderBy(i => i.Name)
                .ToList();
        }

        public Insurance Delete(int id)
        {
            var entity = _context.Remove(new InsuranceEntity {Id = id}).Entity;
            _context.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
            };
        }

        public Insurance Update(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity()
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _context.Update(insuranceEntity).Entity;
            _context.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}