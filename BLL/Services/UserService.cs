using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            this._userRepo = userRepo;
        }

        public void AddUser(UserDTO user)
        {
            var entity = new User()
            {

                FirstName = user.FirstName,
                LastName = user.Surname,
                Email = user.Email,
                Tel = user.Tel,
                DateOfBirth = user.DateOfBirth,

            };

            _userRepo.CreateUser(entity);

        }

        public void DeleteUser(UserDTO user)
        {
            var entity = new User()
            {

                FirstName = user.FirstName,
                LastName = user.Surname,
                Email = user.Email,
                Tel = user.Tel,
                DateOfBirth = user.DateOfBirth,

            };

            _userRepo.DeleteUser(entity);
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepo.GetUserById(id);

            if (user == null)
            {
                // Handle with middleware for logs
                throw new Exception("User not found");
            }

            var result = new UserDTO()
            {
                UserId = user.UserId,
                Surname = user.LastName,
                Email = user.Email,
                Tel = user.Tel,
                DateOfBirth = user.DateOfBirth,
            };

            return result;

        }

        public List<UserDTO> GetUsers(int pageNum = 1, int pageSize = 10)
        {
            var listOfUsers = _userRepo.GetUsers(pageNum, pageSize);

            return listOfUsers.Select(x => new UserDTO
            {
                FirstName = x.FirstName,
                Surname = x.LastName,
                Email = x.Email,
                Tel = x.Tel,
                DateOfBirth = x.DateOfBirth
            }).ToList();
        }

        public void UpdateUser(UserDTO user)
        {
            var entity = new User()
            {

                FirstName = user.FirstName,
                LastName = user.Surname,
                Email = user.Email,
                Tel = user.Tel,
                DateOfBirth = user.DateOfBirth,

            };

            _userRepo.UpdateUser(entity);

        }
    }
}
