using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.net_core.Models;
using Asp.net_core.Interfaces;

namespace Asp.net_core.Repository
{
    public class Repository : IRepository
    {
        private readonly TestDbcontext _context;
        public Repository(TestDbcontext context)
        {
          _context = context;
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.Name).ToList();
        }

        public void PostOwners(int name)
        {
            var owner = new Owner(){
                Name = name,
            };
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }
    }
}