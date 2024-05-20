using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<User> GetUsers(int pageNum=1, int pageSize=10);
        User? GetUserById(int id);
    }
}
