using Asp.net_core.DTO.CarDto;
using Asp.net_core.DTO.UserDto;
using Asp.net_core.DTO.ReceiptsDto;
using Asp.net_core.DTO.VendorDto;
using Asp.net_core.Models;
using AutoMapper;

namespace Asp.net_core.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, ResponeUserDto>();
            CreateMap<TokenUserDto, User>();
            CreateMap<RegisterUserDto, User>();           

            CreateMap<UpdateCarDto, Car>();
            CreateMap<PostCarDto, Car>();
            CreateMap<Car, UpdateCarDto>();
            CreateMap<Car, ResponeCarDto>();

            CreateMap<PostVendorDto, Vendor>();
            CreateMap<UpdateVendorDto, Vendor>();
            CreateMap<Vendor, UpdateVendorDto>();
            CreateMap<ResponeVendorDto, Vendor>();
            CreateMap<Vendor, ResponeVendorDto>();

            CreateMap<PostReceiptDto, Receipt>();
            CreateMap<UpdateReceiptDto, Receipt>();
            CreateMap<Receipt, ResponeReceiptDto>();
            CreateMap<ResponeReceiptDto, Receipt>();
            CreateMap<Receipt, ReceiptOfUserResponeDto>();   
            CreateMap<Receipt, ReceiptOfCarResponeDto>();
            CreateMap<Receipt, ReceiptOfVendorResponeDto>();           
        }
    }
}