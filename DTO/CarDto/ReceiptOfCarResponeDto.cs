using Asp.net_core.DTO.UserDto;
using Asp.net_core.DTO.VendorDto;

namespace Asp.net_core.DTO.CarDto
{
    public class ReceiptOfCarResponeDto
    {
        public UserDTO? User {get; set;}

        public UpdateVendorDto? Vendor {get; set;}
    }
}