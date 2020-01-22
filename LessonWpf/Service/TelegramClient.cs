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

            var handler = new HttpClientHandler();
            Client = new HttpClient(handler);
        }

        private ILogger Logger { get; }
        private String BotToken { get; }
        private HttpClient Client { get; set; }

        public async Task SendMessageAsync(string ChatId, string Message)
        {
            string url = GetUrl("sendMessage") 
                + $"?chat_id={ChatId}&text={Message}"
            ;
            Logger.LogInformation("Попытка отправить данные в телегу");
                Client.Timeout = TimeSpan.FromSeconds(10);
            var response = await Client.GetAsync(url);
            //var response = await Client.GetAsync("https://ya.ru");

            Logger.LogInformation(response.StatusCode.ToString());
        }
        private string GetUrl(string Method)
        {
            return $"https://api.telegram.org/bot{BotToken}/{Method}";
        }
    }
}
