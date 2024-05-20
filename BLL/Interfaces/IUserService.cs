using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {

        public void AddUser(UserDTO user);
        public void UpdateUser(UserDTO user);
        public void DeleteUser(UserDTO user);
        public List<UserDTO> GetUsers(int pageNum=1, int pageSize=10);
        public UserDTO GetUserById(int id);

    }
}
