using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Asp.net_core.Models;


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
        public ActionResult PostOwners(int name)
        {
             _repository.PostOwners(name);
             return Ok();
        }
    }
}



