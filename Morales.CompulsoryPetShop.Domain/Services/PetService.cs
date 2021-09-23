using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }


        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }
        

        public Pet RemovePet(int id)
        {
            return _petRepository.RemovePet(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public Pet ReadByPetId(int id)
        {
            return _petRepository.ReadByPetId(id);
        }

        public List<Pet> ReadAllPets()
        {
            return _petRepository.ReadAllPets();
        }

        public Pet Create(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePetName(int id, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}