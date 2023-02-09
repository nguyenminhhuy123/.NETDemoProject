using Asp.net_core.DTO.CarDto;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using Asp.net_core.Static;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarsRepository _carRepository;
        
        public CarsController(ICarsRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        /**
        * Get all cars.
        *
        * @return all cars
        */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponeCarDto))]
        [ProducesResponseType(400)]
        public ActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            var responeCarDto = _mapper.Map<IList<ResponeCarDto>>(cars);
            return Ok(responeCarDto);
        }

        /**
        * Add a car
        *
        * @param postCarDto (car information)
        * @return Status code
        */
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult PostCar([FromBody]PostCarDto postCarDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<Car>(postCarDto);
            _carRepository.PostCar(car);
            return Ok();
        }

        /**
        * Update a car by id.
        *
        * @param updateCarDto (car information to update)
        * @return Status code
        */
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult PutCar([FromBody]UpdateCarDto updateCarDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<Car>(updateCarDto);
            _carRepository.PutCar(car);
            return Ok();
        }

        /**
        * Delete a car by id
        *
        * @param id (id to delete)
        * @return Status code
        */
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult DeleteCar(int id)
        {
            if(!_carRepository.IsExist(id)){
                return NotFound();
            }

            var car = _carRepository.GetCarById(id);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(!_carRepository.DeleteCar(car)){
                ModelState.AddModelError("","Something went wrong deleting the car");
                return StatusCode(500, ModelState);
            };
            return Ok();
        }

    }
}