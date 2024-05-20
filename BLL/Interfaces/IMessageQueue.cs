using BLL.DTO;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageQueue
    {

        void PutMessage<T>(T input, string messageType);

        public IModel GetChannel();

    }
}
