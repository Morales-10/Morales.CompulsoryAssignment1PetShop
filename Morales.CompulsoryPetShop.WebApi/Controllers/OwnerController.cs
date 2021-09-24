using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;

namespace Morales.CompulsoryPetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public void Create(Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        [HttpGet]
        public ActionResult<List<Owner>> GetAllOwner()
        {
            return Ok(_ownerService.ReadAllOwner());
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwnerById(int id)
        {
            return Ok(_ownerService.ReadByOwnerId(id));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _ownerService.RemoveOwner(id);
        }


    }
}