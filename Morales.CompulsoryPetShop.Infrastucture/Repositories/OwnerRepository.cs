using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.Infrastucture.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> _ownerTable = new List<Owner>();
        private static int _id = 1;

        public List<Owner> GetAllOwners()
        {
            Owner owner1 = new Owner();
            owner1.Id = 1;
            owner1.Name = "Ole";
            _ownerTable.Add(owner1);
            
            Owner owner2 = new Owner();
            owner2.Id = 2;
            owner2.Name = "Poul";
            _ownerTable.Add(owner2);

            Owner owner3 = new Owner();
            owner3.Id = 3;
            owner3.Name = "Kalle";
            _ownerTable.Add(owner3);

            return _ownerTable;
        }

        public Owner CreateOwner(Owner owner)
        {
            _ownerTable.Add(owner);
            return owner;
        }

        public Owner RemoveOwner(int id)
        {
            var owner = ReadByOwnerId(id);
            _ownerTable.Remove(_ownerTable.FirstOrDefault(o => o.Id == id));
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var OwnerOld = _ownerTable.FirstOrDefault(o => o.Id == owner.Id);
            if (OwnerOld != null)
            {
                OwnerOld.Name = owner.Name;
            }
            return null;
        }

        public Owner ReadByOwnerId(int id)
        {
            foreach (var owner in _ownerTable)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public List<Owner> ReadAllOwner()
        {
            return _ownerTable;
        }
    }
}