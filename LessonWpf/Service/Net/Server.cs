using LessonWpf.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LessonWpf.Service.Net
{
    public class Server
    {
        public Server(ILogger logger, MessageRepository messageRepository)
        {
            Logger = logger;
            MessageRepository = messageRepository;
            IsRunning = true;
        }
        public bool IsRunning { get; set; }
        private ILogger Logger { get; }
        public MessageRepository MessageRepository { get; }

        public void Start()
        {
            ThreadStart threadStart = new ThreadStart(this.Process);
            Thread serverThread = new Thread(threadStart);
            serverThread.Start();
            Logger.LogInformation("Сервер запущен");
        }

        void Process()
        {
            try
            {
                TcpListener listener = new TcpListener(8888);
                listener.Start();
                do
                {
                    if (listener.Pending())
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Logger.LogInformation($"Принято входящее соединение");
                        ClientIn clientIn = new ClientIn(client, Logger, MessageRepository);

                        ThreadStart threadStart = new ThreadStart(clientIn.Process);
                        Thread clientThread = new Thread(threadStart);
                        clientThread.Start();
                    }
                } while (IsRunning);
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Ошибка сервера: " + e.Message);
            }
        }
    }
}
