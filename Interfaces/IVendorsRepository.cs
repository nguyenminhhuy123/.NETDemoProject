using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface IVendorsRepository
    {
       Task<ICollection<Vendor>> GetVendors(); 

        Task<bool> PostVendor(Vendor vendor);

        bool PutVendor(Vendor vendor);

        Vendor GetVendorById(int id);

        bool IsExist(int id);

        bool DeleteVendor(Vendor vendor);

        bool SaveChanges(); 
    }
}