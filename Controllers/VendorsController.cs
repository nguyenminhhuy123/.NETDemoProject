using Asp.net_core.DTO.VendorDto;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVendorsRepository _vendorRepository;

        public VendorsController(IVendorsRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        /**
        * Get all vendor
        *
        * @param a First number
        * @return All vendor
        */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Vendor))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetVendor()
        {
            var vendors = await _vendorRepository.GetVendors();
            return Ok(vendors);
        }

        /**
        * Add a receipt
        *
        * @param postVendorDto (vendor information to add)
        * @return Status code
        */
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PostVendor([FromBody]PostVendorDto postVendorDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }   
            var vendors = _mapper.Map<Vendor>(postVendorDto);
            if(! await _vendorRepository.PostVendor(vendors)){
                ModelState.AddModelError("","Something went wrong deleting owner");
                return StatusCode(500,ModelState);   
            };
            return Ok();
        }

        /**
        * Update vendor by id
        *
        * @param updateVendorDto (vendor information to update)
        * @return Status code
        */
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult PutVendor([FromBody]UpdateVendorDto updateVendorDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(!_vendorRepository.IsExist(updateVendorDto.Id)){
                return NotFound();
            }
            var vendor = _mapper.Map<Vendor>(updateVendorDto);

            if(! _vendorRepository.PutVendor(vendor)){
                ModelState.AddModelError("","Something went wrong deleting owner");
                return StatusCode(500,ModelState);   
            }
            return Ok();
        }

        /**
        * Delete vendor by id
        *
        * @param id (id to delete)
        * @return Status code
        */
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult DeleteVendor(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(!_vendorRepository.IsExist(id)){
                return NotFound();
            }
            var vendor = _vendorRepository.GetVendorById(id);

            if(! _vendorRepository.DeleteVendor(vendor)){
                ModelState.AddModelError("","Something went wrong deleting owner");
                return StatusCode(500,ModelState);   
            }
            return Ok();
        }
    }
}