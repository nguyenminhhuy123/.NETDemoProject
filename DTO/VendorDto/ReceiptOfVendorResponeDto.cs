using Asp.net_core.DTO.CarDto;
using Asp.net_core.DTO.UserDto;

namespace Asp.net_core.DTO.VendorDto
{
    public class ReceiptOfVendorResponeDto
    {
        public UserDTO? User {get; set;}

        public UpdateCarDto? Car {get; set;} 
        
    }
}