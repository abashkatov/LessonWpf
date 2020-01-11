using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonWpf.Entity;

namespace LessonWpf.Repository
{
    public class MessageRepository
    {
        public MessageRepository()
        {
            Messages = new ConcurrentQueue<Message>();
        }
        public ConcurrentQueue<Message> Messages { get; set; }
    }
}
