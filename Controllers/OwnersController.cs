using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Asp.net_core.Models;
using Asp.net_core.DTO.OwnerDto;

namespace Asp.net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOwnersRepository _ownerRepository;

        public OwnersController(IOwnersRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        /**
        * Get all owners
        *
        * @return All onwers
        */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public ActionResult GetOwners()
        {
            var owners = _ownerRepository.GetOwners();
            return Ok(owners);
        }
        
        /**
        * Add a owner
        *
        * @param name (name of owner)
        * @return Status code
        */
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult PostOwner(string name)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var owner = new Owner(){
                Name = name,
            };
             _ownerRepository.PostOwner(owner);
             return Ok();
        }

        /**
        * Update a owner by id.
        *
        * @param ownerDto (owner information to update)
        * @return Status code
        */
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult PutOwner([FromBody]OwnerDTO ownerDto )
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _ownerRepository.PutOwner(_mapper.Map<Owner>(ownerDto));
             return Ok();
        }

        /**
        * Delete a car by id
        *
        * @param id (id to delete)
        * @return Status code
        */
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult DeleteOwner(int id)
        {
            if(!_ownerRepository.IsExist(id)){
                return NotFound();
            }
            var owner = _ownerRepository.GetOwnerById(id);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(!_ownerRepository.DeleteOwner(owner)){
                ModelState.AddModelError("","Something went wrong deleting owner");
                return StatusCode(500,ModelState);
            };
             return Ok();
        }
    }
}



