using LessonWpf.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service.Net
{
    class ClientIn
    {
        public ClientIn(
            TcpClient client, 
            ILogger logger,
            MessageRepository messageRepository
        ) {
            Client = client;
            Logger = logger;
            MessageRepository = messageRepository;
        }

        private TcpClient Client { get; }
        private ILogger Logger { get; }
        public MessageRepository MessageRepository { get; }

        public void Process()
        {
            StringBuilder message = new StringBuilder();
            using (NetworkStream stream = Client.GetStream())
            {
                string data = "";
                byte[] buff = new byte[64];
                int count = 0;
                do
                {
                    count = stream.Read(buff, 0, buff.Length);
                    data = Encoding.Unicode.GetString(buff, 0, count);
                    message.Append(data);
                } while (stream.DataAvailable);
            }
            Client.Close();
            Entity.Message Message = new Entity.Message();
            Message.Text = message.ToString();
            MessageRepository.Messages.Enqueue(Message);
            Logger.LogInformation("Получено сообщение: " + message);
        }
    }
}
