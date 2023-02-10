using Asp.net_core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Asp.net_core.Models;
using Asp.net_core.DTO.UserDto;

namespace Asp.net_core.Controllers
{
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

        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns>List of user</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponeUserDto))]
        [ProducesResponseType(400)]
        public ActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            var responeUserDto = _mapper.Map<IList<ResponeUserDto>>(users);
            return Ok(responeUserDto);
        }
        
        /// <summary>
        /// Add a user.
        /// </summary>
        /// <param name="registerUserDto"> Information of user </param>
        /// <returns></returns>
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

        /// <summary>
        /// Add a user.
        /// </summary>
        /// <param name="userDto"> Information of user </param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="id"> User id to delete  </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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



