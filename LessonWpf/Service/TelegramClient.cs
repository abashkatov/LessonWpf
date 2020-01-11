using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service
{
    public class TelegramClient
    {
        public TelegramClient(ILogger logger, IConfiguration config) {
            Logger = logger;
            BotToken = config.GetValue<string>("bot_token");
        }

        private ILogger Logger { get; }
        private String BotToken { get; }

        public async Task SendMessageAsync(string ChatId, string Message)
        {
            string url = GetUrl("sendMessage") 
                + $"?chat_id={ChatId}&text={Message}"
            ;
            Logger.LogInformation("Попытка отправить данные в телегу");
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(5);
                var response = await client.GetAsync(url);
                
                Logger.LogInformation(response.StatusCode.ToString());
            }
        }
        private string GetUrl(string Method)
        {
            return $"https://api.telegram.org/bot{BotToken}/{Method}";
        }
    }
}
