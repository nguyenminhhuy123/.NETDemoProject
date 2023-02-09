using Asp.net_core.DTO.VendorDto;
using Asp.net_core.DTO.UserDto;
using Asp.net_core.DTO.CarDto;

namespace Asp.net_core.DTO.ReceiptsDto
{
    public class ResponeReceiptDto
    {
        public int Id {get; set;}

        public UpdateCarDto? Car {get; set;}

        public UpdateVendorDto? Vendor {get; set;}

        public UserDTO? User {get; set;}
    }
}