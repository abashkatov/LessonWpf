﻿using LessonWpf.Service;
using LessonWpf.Service.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LessonWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(
            TelegramClient telegramClient, 
            ILogger logger,
            Server server,
            ClientOut clientOut
            )
        {
            InitializeComponent();
            Logger = logger;
            Server = server;
            ClientOut = clientOut;
            TelegramClient = telegramClient;

            Logger.LogInformation("Старт приложения");
            Server.Start();
            ClientOut.SendMessage("127.0.0.1", "Test");
            //TelegramClient.SendMessageAsync("@asbashkatov", "Hello!");
        }

        private TelegramClient TelegramClient { get; }
        private ILogger Logger { get; }
        private Server Server { get; }
        private ClientOut ClientOut { get; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.IsRunning = false;
        }
    }
}
