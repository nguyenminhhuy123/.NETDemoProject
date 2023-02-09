using Asp.net_core.Models;
using Asp.net_core.Interfaces;
using AutoMapper;
using Asp.net_core.DTO.UserDto;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_core.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMapper _mapper;
        private readonly TestDbcontext _context;
        public UsersRepository(TestDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IList<User> GetUsers()
        {
            var users = _context.Users
            .Include(b => b.Receipts).ThenInclude(i => i.Vendor)
            .Include(b => b.Receipts).ThenInclude(i => i.Car)
            .ToList();
            return users;
        }

        public bool PostUser(User User)
        {
            _context.Users.Add(User);
            return SaveChanges();
        }

        public bool SaveChanges(){
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(User user){
            _context.Users.Remove(user);
            return SaveChanges();
        }

        public bool PutUser(User user)
        {
            _context.Users.Update(user);
            return SaveChanges();
        }

        public bool IsExist(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public string GetRole(User user)
        {
            string role =_context.Users.Where(p => p.Id == user.Id).FirstOrDefault().Role;
            return role;
        }

        public User GetUserByNameAndPassword(User user)
        {
            return _context.Users.Where(p => p.UserName == user.UserName && p.Password == user.Password).FirstOrDefault();
        }

        public bool IsExistByUserNameAndPassword(User user)
        {
            return _context.Users.Any(p => p.UserName == user.UserName && p.Password == user.Password);
        }
    }
}