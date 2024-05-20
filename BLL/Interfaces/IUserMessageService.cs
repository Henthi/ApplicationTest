using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserMessageService
    {
        void PutAddUser(UserDTO inputData);
        void PutUpdateUser(UserDTO inputData);
        void PutDeleteUser(UserDTO inputData);
    }
}
