using System;
using System.Collections.Generic;
using System.Linq;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;
using Morales.CompulsoryPetShop.EntityFramework.Entities;

namespace Morales.CompulsoryPetShop.EntityFramework.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDbContext _context;

        public PetRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public List<Pet> ReadAllPets()
        {
            return _context.Pet.Select(pet => new Pet
                {
                    Id = pet.id,
                    Name = pet.Name,
                    Birthdate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Color = pet.Color,
                    Price = pet.Price,
                })
                .Take(50)
                .OrderBy(p => p.Name)
                .ToList();
        }

        
        public Pet CreatePet(Pet pet)
        {
            var beforeSaveEntity = new PetEntity()
            {
                id = pet.Id,
                Name = pet.Name,
                BirthDate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
            var afterSaveEntity = _context.Pet.Add(beforeSaveEntity).Entity;
            _context.SaveChanges();
            return new Pet()
            {
                Id = afterSaveEntity.id,
                Name = afterSaveEntity.Name,
                Birthdate = afterSaveEntity.BirthDate,
                SoldDate = afterSaveEntity.SoldDate,
                Color = afterSaveEntity.Color,
                Price = afterSaveEntity.Price,
            };
        }

        public Pet RemovePet(int id)
        {
            _context.Pet.Remove(new PetEntity {id = id});
            _context.SaveChanges();
            return new Pet
            {
                Id = id
            };
        }

        public Pet UpdatePet(Pet pet)
        {
            var petEntity = new PetEntity
            {
                id = pet.Id,
                Name = pet.Name,
                BirthDate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
            };
            var entity = _context.Update(petEntity).Entity;
            _context.SaveChanges();
            return new Pet
            {
                Id = entity.id,
                Name = entity.Name,
                Birthdate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price,
            };
        }

        public Pet ReadByPetId(int id)
        {
           
            return _context.Pet
                .Select(pe => new Pet
                {
                    Id = pe.id,
                    Name = pe.Name,
                    Birthdate = pe.BirthDate,
                    SoldDate = pe.SoldDate,
                    Color = pe.Color,
                    Price = pe.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

       
    }
}