using Asp.net_core.Models;
using Asp.net_core.Interfaces;
using Asp.net_core.DTO;
using AutoMapper;

namespace Asp.net_core.Repository
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public Repository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.Name).ToList();
        }

        public bool PostOwner(int name)
        {
            var owner = new Owner(){
                Name = name,
            };
            _context.Owners.Add(owner);
            return SaveChange();
        }

        public bool SaveChange(){
            return _context.SaveChanges() > 0;
        }

        public bool DeleteOwner(int id){
            var owner = new Owner(){
                Id = id,
            };
            _context.Owners.Remove(owner);
            return SaveChange();
        }

        public bool PutOwner(OwnerDto ownerDto)
        {
            _context.Owners.Update(_mapper.Map<Owner>(ownerDto));
            return SaveChange();
        }
    }
}