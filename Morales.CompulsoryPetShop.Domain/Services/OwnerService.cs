using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        public IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner RemoveOwner(int id)
        {
            return _ownerRepository.RemoveOwner(id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner ReadByOwnerId(int id)
        {
            return _ownerRepository.ReadByOwnerId(id);
        }

        public List<Owner> ReadAllOwner()
        {
            return _ownerRepository.ReadAllOwner();
        }
    }
}