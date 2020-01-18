using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service.Logging
{
    public class TelegramLogger : ILogger
    {
        private string Channel;
        private static object _lock = new object();
        public TelegramLogger(string channel)
        {
            Channel = channel;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter
        )
        {
            if (formatter != null)
            {
                
            }
        }
    }
}
