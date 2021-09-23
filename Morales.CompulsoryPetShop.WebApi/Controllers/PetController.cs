using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;  
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IPetTypeService _petTypeService;
        
        public PetController(IPetService service, IPetTypeService petTypeService)
        {
            _petService = service;
            _petTypeService = petTypeService;
        }


        [HttpPost]
        public void Create(Pet pet)
        {
            _petService.CreatePet(pet);
        }
        
        //Read All Pets
        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
          return Ok(_petService.ReadAllPets());
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            return Ok(_petService.GetById(id));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _petService.Delete(id);
        }

        [HttpPatch]
        public void UpdatePetName(int id, string name)
        {
            _petService.UpdatePetName(id, name);
        }
    }
}