using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        public Insurance GetById(int id);
        
    }
}