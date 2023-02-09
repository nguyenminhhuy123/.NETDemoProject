using Asp.net_core.DTO.CarDto;
using Asp.net_core.DTO.VendorDto;

namespace Asp.net_core.DTO.UserDto
{
    public class ReceiptOfUserResponeDto
    {
        public UpdateCarDto? Car {get; set;}

        public UpdateVendorDto? Vendor {get; set;}
    }
}