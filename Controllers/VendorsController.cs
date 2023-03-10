using Asp.net_core.DTO.VendorDto;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using Asp.net_core.Static;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Get all vendor.
        /// </summary>
        /// <returns>List of vendor</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponeVendorDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetVendor()
        {
            var vendors = await _vendorRepository.GetVendors();
            var responeVendorDto = _mapper.Map<IList<ResponeVendorDto>>(vendors);
            return Ok(responeVendorDto);
        }

        /// <summary>
        /// Add a vendor.
        /// </summary>
        /// <param name="postVendorDto"> Information of vendor </param>
        /// <returns></returns>
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

        /// <summary>
        /// Add a vendor.
        /// </summary>
        /// <param name="updateVendorDto"> Information of vendor </param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a vendor.
        /// </summary>
        /// <param name="id"> Vendor id to delete  </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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