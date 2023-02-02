using System.Data.Entity;
using Asp.net_core.Interfaces;
using Asp.net_core.Models;
using AutoMapper;

namespace Asp.net_core.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public CarsRepository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ICollection<Car> GetCars()
        {
            var test = _context.Cars.Include(b => b.Receipt).OrderBy(p => p.Name).ToList();
            return test;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> PostCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            return SaveChanges();
        }

        public bool PutCar(Car car)
        {
            _context.Cars.Update(car);
            return SaveChanges();
        }

        public bool DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            return SaveChanges();
        }

        public bool IsExist(int id){
            return _context.Cars.Any(p => p.Id == id);    
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}