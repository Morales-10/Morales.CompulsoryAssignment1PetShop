using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Core.IServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        Owner RemoveOwner(int id);
        Owner UpdateOwner(Owner owner);
        Owner ReadByOwnerId(int id);

        List<Owner> ReadAllOwner();
    }
}