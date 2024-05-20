using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationContext _ctx;

        public UserRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        public void CreateUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
        }

        public List<User> GetUsers(int pageNum, int pageSize)
        {
            return _ctx.Users.Skip((pageNum-1) * pageSize)
                .Take(pageSize).ToList();
            

        }

        public User? GetUserById(int id)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.UserId == id);
            return user;
            
        }
    }
}
