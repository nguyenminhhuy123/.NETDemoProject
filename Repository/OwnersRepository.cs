using Asp.net_core.Models;
using Asp.net_core.Interfaces;
using AutoMapper;
using Asp.net_core.DTO.Owner;
using System.Data.Entity;

namespace Asp.net_core.Repository
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public OwnersRepository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ICollection<ResponeOwnerDto> GetOwners()
        {
            var Owners = _context.Owners.Include(b => b.Receipts).OrderBy(p => p.Name).ToList();
            var responeOwnerDtos = _mapper.Map<ICollection<ResponeOwnerDto>>(Owners);
            return responeOwnerDtos;
        }

        public bool PostOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return SaveChanges();
        }

        public bool SaveChanges(){
            return _context.SaveChanges() > 0;
        }

        public bool DeleteOwner(Owner owner){
            _context.Owners.Remove(owner);
            return SaveChanges();
        }

        public bool PutOwner(Owner owner)
        {
            _context.Owners.Update(owner);
            return SaveChanges();
        }

        public bool IsExist(int id)
        {
            return _context.Owners.Any(p => p.Id == id);
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}