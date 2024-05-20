using BLL.DTO;
using BLL.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace API.Background
{
    public class UserMutationHandler : BackgroundService
    {
        private readonly IMessageQueue _queue;
        private readonly IUserService _userService;

        public UserMutationHandler(IMessageQueue queue, IUserService userService)
        {

            this._queue = queue;
            this._userService = userService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = this._queue.GetChannel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                HandleMessage(content);
                // copy or deserialise the payload
                // and process the message
                // ...
                channel.BasicAck(ea.DeliveryTag, false);
            };
            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = channel.BasicConsume("userQueue", false, consumer);


            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {

            var deserialised = JsonSerializer.Deserialize<MessageQueueData<object>>(content);

            if (deserialised == null)
            {
                return;
            }

            switch (deserialised.MessageType)
            {

                case "addUser":
                    var addUserdata = deserialised.Data as UserDTO;
                    AddUser(addUserdata);
                    break;

                case "updateUser":
                    var updateUserdata = deserialised.Data as UserDTO;
                    UpdateUser(updateUserdata);
                    break;

                case "deleteUser":
                    var deleteUserData = deserialised.Data as UserDTO;
                    DeleteUser(deleteUserData);
                    break;

                default:
                    return;

            }

        }

        private void AddUser(UserDTO user)
        {
            _userService.AddUser(user);
        }

        private void UpdateUser(UserDTO user)
        {
            _userService.UpdateUser(user);
        }

        private void DeleteUser(UserDTO user)
        {
            _userService.DeleteUser(user);
        }

    }
}
