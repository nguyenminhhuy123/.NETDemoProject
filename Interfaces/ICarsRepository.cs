using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface ICarsRepository
    {
        ICollection<Car> GetCars(); 

        Task<ICollection<Car>> GetCarsByVendor(int id); 

        Task<bool> PostCar(Car car);

        bool PutCar(Car car);

        bool DeleteCar(Car car);

        Car GetCarById(int id);

        bool IsExist(int id);

        bool SaveChanges(); 
    }
}