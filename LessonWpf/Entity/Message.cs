﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Entity
{
    public class Message
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Createdon { get; set; } = DateTime.Now;
    }
}