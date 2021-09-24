using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpPost]
        public void Create(PetType petType)
        {
            _petTypeService.CreatePetType(petType);
        }

        [HttpGet]
        public ActionResult<List<PetType>> GetAllPetTypes()
        {
            return Ok(_petTypeService.ReadAllPetTypes());
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> ReadById(int id)
        {
            return Ok(_petTypeService.ReadById(id));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _petTypeService.RemovePetType(id);
        }
    }
}