using Asp.net_core.DTO.VendorDto;
using Asp.net_core.DTO.OwnerDto;
using Asp.net_core.Models;
using Asp.net_core.DTO.CarDto;

namespace Asp.net_core.DTO.ReceiptsDto
{
    public class ResponeReceiptDto
    {
        public UpdateVendorDto? Vendors {get; set;}

        public UpdateCarDto? Cars {get; set;}
    }
}