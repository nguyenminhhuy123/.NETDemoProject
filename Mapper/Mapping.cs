using Asp.net_core.DTO;
using Asp.net_core.DTO.CarDto;
using Asp.net_core.DTO.OwnerDto;
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
            CreateMap<OwnerDTO, Owner>();
            CreateMap<Owner, ResponeOwnerDto>();
            CreateMap<Owner, ResponeOwnerDto>();

            CreateMap<UpdateCarDto, Car>();
            CreateMap<PostCarDto, Car>();

            CreateMap<PostVendorDto, Vendor>();
            CreateMap<UpdateVendorDto, Vendor>();

            CreateMap<PostReceiptDto, Receipt>();
            CreateMap<UpdateReceiptDto, Receipt>();
            CreateMap<Receipt, ResponeReceiptDto>();
        }
    }
}