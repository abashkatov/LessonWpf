using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service.Client
{
    class Telegram
    {
        public Telegram(ILogger logger, IConfiguration config)
        {
            BotToken = config.GetValue<string>("bot_token");
            Logger = logger;
        }

        public string BotToken { get; }
        public ILogger Logger { get; }
    }
}
