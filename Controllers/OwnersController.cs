using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Asp.net_core.DTO;
using AutoMapper;
using Asp.net_core.Models;

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

        [HttpGet]
        public ActionResult GetOwners()
        {
            var owners = _ownerRepository.GetOwners();
            return Ok(owners);
        }
        
        [HttpPost]
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

        [HttpPut]
        public ActionResult PutOwner([FromBody]OwnerDto ownerDto )
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _ownerRepository.PutOwner(_mapper.Map<Owner>(ownerDto));
             return Ok();
        }

        [HttpDelete]
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



