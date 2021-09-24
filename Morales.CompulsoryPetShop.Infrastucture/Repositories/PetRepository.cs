using System;
using System.Collections.Generic;
using System.Linq;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.Infrastucture.Repositories
{
    public class PetRepository : IPetRepository
    
    {
        private static List<Pet> _petTable = new List<Pet>();
        private List<PetType> _petTypes = new PetTypeRepository().ReadAllPetTypes();
        private static int _id = 1;
     

        public PetRepository()
        {
            CreatePet(new Pet()
            {
                Name = "Anna",
                Type = _petTypes[1],
                Color = "Black",
                Price = 300000,
                Birthdate = DateTime.Now,
                SoldDate = DateTime.Now
            });
            
            CreatePet(new Pet()
            {
                Name = "Robert",
                Type = _petTypes[2],
                Color = "White",
                Price = 240000,
                Birthdate = DateTime.Now,
                SoldDate = DateTime.Now
            });
            CreatePet(new Pet()
            {
                Name = "Adriana",
                Type = _petTypes[3],
                Color = "Red",
                Price = 540000,
                Birthdate = DateTime.Now,
                SoldDate = DateTime.Now
            });
            CreatePet(new Pet()
            {
                Name = "Oskar",
                Type = _petTypes[4],
                Color = "Blue",
                Price = 230000,
                Birthdate = DateTime.Now,
                SoldDate = DateTime.Now
            });
        }
        
        public Pet CreatePet(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public List<Pet> ReadAllPets()
        {
            return _petTable;
        }

          public Pet ReadByPetId(int id)
                {
                    foreach (var pet in _petTable)
                    {
                        if (pet.Id == id)
                        {
                            return pet;
                        }
                    }
        
                    return null;
                }
          
        public Pet RemovePet(int id)
        {
            var pet = ReadByPetId(id);
            _petTable.Remove(_petTable.FirstOrDefault(p => p.Id == id));
            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            var petOld = _petTable.FirstOrDefault(p => p.Id == pet.Id);
            if (petOld != null)
            {
                petOld.Name = pet.Name;
                petOld.Color = pet.Color;
                petOld.Price = pet.Price;
                petOld.Birthdate = pet.Birthdate;
                petOld.SoldDate = pet.SoldDate;
            }

            return null;
        }
    }
}