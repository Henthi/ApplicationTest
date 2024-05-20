using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MessageQueueData<T>
    {
        public MessageQueueData()
        {
            
        }

        public MessageQueueData(T input, string messageType)
        {
            Data = input;
            MessageType = messageType;
            
        }

        public string MessageType { get; set; }
        public T Data { get; set; }

    }
}
