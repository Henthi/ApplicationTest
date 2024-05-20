using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class UserMessageService :IUserMessageService
    {
        private readonly IMessageQueue _queue;

        public UserMessageService(IMessageQueue queue)
        {
            this._queue = queue;
        }

        public void PutAddUser(UserDTO inputData)
        {
            _queue.PutMessage(inputData, "addUser"); 
        }

        public void PutUpdateUser(UserDTO inputData)
        {
            _queue.PutMessage(inputData, "updateUser");
        }

        public void PutDeleteUser(UserDTO inputData)
        {
            _queue.PutMessage(inputData, "deleteUser");
        }

    }
}
