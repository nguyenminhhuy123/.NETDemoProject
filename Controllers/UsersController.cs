using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Asp.net_core.Models;
using Asp.net_core.DTO.UserDto;
using Microsoft.AspNetCore.Authorization;
using Asp.net_core.Static;

namespace Asp.net_core.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;

        public UsersController(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /**
        * Get all Users
        *
        * @return All onwers
        */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponeUserDto))]
        [ProducesResponseType(400)]
        public ActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            var responeUserDto = _mapper.Map<IList<ResponeUserDto>>(users);
            return Ok(responeUserDto);
        }
        
        /**
        * Add a User
        *
        * @param name (name of User)
        * @return Status code
        */
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult PostUser(RegisterUserDto registerUserDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _userRepository.PostUser
            (
                _mapper.Map<User>(registerUserDto)
            );
            return Ok();
        }

        /**
        * Update a User by id.
        *
        * @param UserDto (User information to update)
        * @return Status code
        */
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult PutUser([FromBody]UserDTO userDto )
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
             _userRepository.PutUser(_mapper.Map<User>(userDto));
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
        public ActionResult DeleteUser(int id)
        {
            if(!_userRepository.IsExist(id)){
                return NotFound();
            }
            var User = _userRepository.GetUserById(id);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(!_userRepository.DeleteUser(User)){
                ModelState.AddModelError("","Something went wrong deleting User");
                return StatusCode(500,ModelState);
            };
             return Ok();
        }
    }
}



