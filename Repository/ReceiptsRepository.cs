using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_core.Repository
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public ReceiptsRepository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool DeleteReceipt(Receipt receipt)
        {
            _context.Receipts.Remove(receipt);
            return SaveChanges();
        }

        public Receipt GetReceiptById(int id)
        {
            return _context.Receipts.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task<ICollection<Receipt>> GetReceipts()
        {
            var test = await _context.Receipts.Include(p => p.Car)
            .Include(b => b.Owner)
            .Include(n => n.Vendor)
            .ToListAsync();
            return await _context.Receipts.Include(p => p.Car)
            .Include(b => b.Owner)
            .Include(n => n.Vendor)
            .ToListAsync();
        }

        public bool IsExist(int id)
        {
            return _context.Receipts.Any(p => p.Id == id);
        }

        public async Task<bool> PostReceipt(Receipt receipt)
        {
            await _context.Receipts.AddAsync(receipt);
            return SaveChanges();
        }

        public bool PutReceipt(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            return SaveChanges(); 
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}