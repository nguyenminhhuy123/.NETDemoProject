using Asp.net_core.DTO;
using Asp.net_core.DTO.Car;
using Asp.net_core.DTO.Owner;
using Asp.net_core.DTO.Receipts;
using Asp.net_core.DTO.Vendor;
using Asp.net_core.Models;
using AutoMapper;

namespace Asp.net_core.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, ResponeOwnerDto>();

            CreateMap<UpdateCarDto, Car>();
            CreateMap<PostCarDto, Car>();

            CreateMap<PostVendorDto, Vendor>();
            CreateMap<UpdateVendorDto, Vendor>();

            CreateMap<PostReceiptDto, Receipt>();
            CreateMap<UpdateReceiptDto, Receipt>();
        }
    }
}