using LessonWpf.Entity;
using LessonWpf.Service;
using LessonWpf.Service.Net;
using LessonWpf.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            Messages = new ObservableCollection<Message>();
            Messages.Add(new Message("Text 1"));
            Messages.Add(new Message("Text 2"));
            Messages.Add(new Message("Text 3"));

            var context = new MainWindowViewModel(Messages);
            context.Messages = Messages;
            DataContext = context;

            Server.Start();
            ClientOut.SendMessage("127.0.0.1", "Test");
            //TelegramClient.SendMessageAsync("@asbashkatov", "Hello!");
        }

        private ObservableCollection<Message> Messages;
        private TelegramClient TelegramClient { get; }
        private ILogger Logger { get; }
        private Server Server { get; }
        private ClientOut ClientOut { get; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.IsRunning = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Messages.Add(new Message("По кнопке"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (null != (DataContext as MainWindowViewModel).SelectedMessage)
            {
                Messages.Remove((DataContext as MainWindowViewModel).SelectedMessage);
            }
        }
    }
}
