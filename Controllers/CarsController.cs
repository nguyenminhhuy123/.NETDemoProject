using Asp.net_core.DTO.CarDto;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        /// <summary>
        /// Get all cars.
        /// </summary>
        /// <returns>List of car</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponeCarDto))]
        [ProducesResponseType(400)]
        public ActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            var responeCarDto = _mapper.Map<IList<ResponeCarDto>>(cars);
            return Ok(responeCarDto);
        }


        /// <summary>
        /// Get cars sell by vendor.
        /// </summary>
        /// <returns>List of car</returns>
        [HttpGet("{vendorId}")]
        [ProducesResponseType(200, Type = typeof(CarDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetCarByVendor(int vendorId)
        {
            var cars = await _carRepository.GetCarsByVendor(vendorId);
            var CarDto = _mapper.Map<IList<CarDto>>(cars);
            return Ok(CarDto);
        }

        /// <summary>
        /// Add a car.
        /// </summary>
        /// <param name="postCarDto"> car information </param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a car by id.
        /// </summary>
        /// <param name="updateCarDto"> UpdateCarDto(car information to update) </param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a car by id.
        /// </summary>
        /// <param name="id"> Id to delete </param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a car using json patch.
        /// </summary>
        /// <param name="patchDoc"> json patch document </param>
        /// <param name="id"> Id to update </param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PatchCar(int id, [FromBody] JsonPatchDocument<Car> patchDoc)
        {
            if (patchDoc != null)
            {
                var car = _carRepository.GetCarById(id);
                patchDoc.ApplyTo(car, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(!_carRepository.SaveChanges()){
                    ModelState.AddModelError("","Something went wrong updating the car");
                    return StatusCode(500, ModelState);                   
                }
                   
                return Ok(car);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}