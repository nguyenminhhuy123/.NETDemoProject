using Asp.net_core.DTO.ReceiptsDto;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReceiptsRepository _receiptsRepository;
        private readonly IOwnersRepository _ownersRepository;
        private readonly ICarsRepository _carsRepository;
        private readonly IVendorsRepository _vendorsRepository;

        public ReceiptController
        (
            IReceiptsRepository receiptsRepository,
            IMapper mapper,
            IOwnersRepository ownersRepository,
            ICarsRepository carsRepository,
            IVendorsRepository vendorsRepository)
        {
            _receiptsRepository = receiptsRepository;
            _ownersRepository = ownersRepository;
            _carsRepository = carsRepository;
            _vendorsRepository = vendorsRepository;
            _mapper = mapper;
        }

        /**
        * Get all ceceipt
        *
        * @return All onwers
        */
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Receipt))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetReceipt()
        {
            var receipt = await _receiptsRepository.GetReceipts();
            
            return Ok(receipt);
        }

        /**
        * Add a receipt
        *
        * @param postReceiptDto (include car id, owner id, vendor id)
        * @return Status code
        */
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult PostReceipt([FromBody]PostReceiptDto postReceiptDto)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }
            int idOwner = postReceiptDto.IdOwner;
            int idCar = postReceiptDto.IdCar;
            int idVendor = postReceiptDto.IdVendor;
            if(!_ownersRepository.IsExist(idOwner)|| 
            !_carsRepository.IsExist(idCar) ||
            !_vendorsRepository.IsExist(idVendor))
            {
                return NotFound();
            }
            var receipt = _mapper.Map<Receipt>(postReceiptDto);
            var owner = _ownersRepository.GetOwnerById(postReceiptDto.IdOwner);
            var car = _carsRepository.GetCarById(postReceiptDto.IdCar);
            var vendor = _vendorsRepository.GetVendorById(postReceiptDto.IdVendor);
            receipt.Car = car;
            receipt.Owner = owner;
            receipt.Vendor = vendor;
            if(!_receiptsRepository.PostReceipt(receipt)){
                ModelState.AddModelError("","Something went wrong posting receipt");
                return StatusCode(500,ModelState);
            }
            return Ok();
        }

        /**
        * Update a ceceipt by id.
        *
        * @param updateReceiptDto (receipt information to update)
        * @return Status code
        */
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult PutReceipt([FromBody]UpdateReceiptDto updateReceiptDto)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }
            int idOwner = updateReceiptDto.IdOwner;
            int idCar = updateReceiptDto.IdCar;
            int idVendor = updateReceiptDto.IdVendor;
            if(!_ownersRepository.IsExist(idOwner)|| 
            !_carsRepository.IsExist(idCar) ||
            !_vendorsRepository.IsExist(idVendor))
            {
                return NotFound();
            }
            var receipt = _mapper.Map<Receipt>(updateReceiptDto);
            if(!_receiptsRepository.PutReceipt(receipt)){
                ModelState.AddModelError("","Something went wrong updating receipt");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        /**
        * Delete a receipt by id
        *
        * @param id (id to delete)
        * @return Status code
        */
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult DeleteReceipt(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(!_receiptsRepository.IsExist(id))
            {
                return NotFound();
            }
            var receipt = _receiptsRepository.GetReceiptById(id);     
            if(!_receiptsRepository.DeleteReceipt(receipt))
            {
                ModelState.AddModelError("","Something went wrong deleting receipt");
                return StatusCode(500, ModelState);
            }
            return Ok();       
        }
    }
}