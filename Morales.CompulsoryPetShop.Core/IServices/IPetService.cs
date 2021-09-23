using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Core.IServices
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        Pet RemovePet(int id);
        Pet UpdatePet(Pet pet);
        Pet ReadByPetId(int id);

        List<Pet> ReadAllPets();

        Pet Create(Pet pet);
        object GetById(int id);
        void Delete(int id);
        void UpdatePetName(int id, string name);
    }
    
}