using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);
        Pet RemovePet(int id);
        Pet UpdatePet(Pet pet);
        Pet ReadByPetId(int id);

        List<Pet> ReadAllPets();
    }
}