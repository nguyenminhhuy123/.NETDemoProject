using Asp.net_core.Models;

namespace Asp.net_core.Interfaces
{
    public interface IUsersRepository
    {
        IList<User> GetUsers(); 

        User GetUserByNameAndPassword(User user);

        bool IsExistByUserNameAndPassword(User user);

        bool PostUser(User user);

        bool PutUser(User user);

        User GetUserById(int id);

        bool IsExist(int id);

        bool DeleteUser(User user);

        string GetRole(User user);

        bool SaveChanges(); 
    }
}