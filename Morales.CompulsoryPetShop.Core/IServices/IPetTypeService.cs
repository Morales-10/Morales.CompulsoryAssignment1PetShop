using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Core.IServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);
        PetType RemovePetType(int id);
        PetType UpdatePetType(PetType petType);
        PetType ReadById(int id);

        List<PetType> ReadAllPetTypes();
    }
}