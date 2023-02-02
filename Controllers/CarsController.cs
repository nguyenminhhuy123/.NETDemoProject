using Asp.net_core.DTO.Car;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core.Controllers
{
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

        [HttpGet]
        public ActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public ActionResult PostCar([FromBody]PostCarDto postCarDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<Car>(postCarDto);
            _carRepository.PostCar(car);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutCar([FromBody]UpdateCarDto updateCarDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<Car>(updateCarDto);
            _carRepository.PutCar(car);
            return Ok();
        }

        [HttpDelete]
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