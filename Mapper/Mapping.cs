using Asp.net_core.DTO;
using Asp.net_core.Models;
using AutoMapper;

namespace Asp.net_core.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OwnerDto, Owner>();
        }
    }
}