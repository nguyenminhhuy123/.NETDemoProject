using Microsoft.EntityFrameworkCore;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;

namespace Asp.net_core.Repository
{
    public class VendorsRepository : IVendorsRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public VendorsRepository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public bool DeleteVendor(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
            return SaveChanges();
        }

        public Vendor GetVendorById(int id)
        {
            return _context.Vendors.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task<ICollection<Vendor>> GetVendors()
        {
            return await _context.Vendors
            .Include(p => p.Receipts).ThenInclude(i => i.Car)
            .Include(o => o.Receipts).ThenInclude(y => y.User)
            .ToListAsync();   
        }

        public bool IsExist(int id)
        {
            return _context.Vendors.Any(p => p.Id == id);
        }

        public async Task<bool> PostVendor(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
            return SaveChanges();
        }

        public bool PutVendor(Vendor Vendor)
        {
            _context.Vendors.Update(Vendor);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}