using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service.Net
{
    public class ClientOut
    {
        public ClientOut(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public void SendMessage(string dest, string message)
        {
            try
            {
                using (var client = new TcpClient(dest, 8888))
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = Encoding.Unicode.GetBytes(message);
                        stream.Write(data, 0, data.Length);
                        Logger.LogInformation("Сообщение отправлено");
                    }
                }
            }
            catch (Exception e) {
                Logger.LogError($"Не удалось отправить сообщение: {e.Message}");
            }
        }
    }
}
