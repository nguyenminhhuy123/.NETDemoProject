using Asp.net_core.DTO.OwnerDto;
using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface IOwnersRepository
    {
        ICollection<Owner> GetOwners(); 

        bool PostOwner(Owner owner);

        bool PutOwner(Owner owner);

        Owner GetOwnerById(int id);

        bool IsExist(int id);

        bool DeleteOwner(Owner owner);

        bool SaveChanges(); 
    }
}