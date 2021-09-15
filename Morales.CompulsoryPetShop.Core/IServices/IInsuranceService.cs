using System.Collections.Generic;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance GetById(int Id);
        
    }
}