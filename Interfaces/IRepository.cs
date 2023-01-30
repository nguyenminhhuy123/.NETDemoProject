using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.net_core.DTO;
using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface IRepository
    {
        ICollection<Owner> GetOwners(); 

        bool PostOwner(int name);

        bool PutOwner(OwnerDto owner);

        bool DeleteOwner(int id);

        bool SaveChange(); 
    }
}