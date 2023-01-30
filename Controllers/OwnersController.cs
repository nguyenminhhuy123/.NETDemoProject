using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Asp.net_core.DTO;

namespace Asp.net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IRepository _repository;
        public OwnersController( IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult GetOwners()
        {
            var owners = _repository.GetOwners();
            return Ok(owners);
        }
        [HttpPost]
        public ActionResult PostOwner(int name)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _repository.PostOwner(name);
             return Ok();
        }

        [HttpPut]
        public ActionResult PutOwner([FromBody]OwnerDto ownerDto )
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _repository.PutOwner(ownerDto);
             return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteOwner(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _repository.DeleteOwner(id);
             return Ok();
        }
    }
}



