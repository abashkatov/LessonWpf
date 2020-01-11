using LessonWpf.Service.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LessonWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void StartupDo(Object sender, StartupEventArgs e)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<MainWindow, MainWindow>();
            #region ConfigLogger
            string LogPath = "logger.txt";
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("WpfApp1", LogLevel.Debug)
                    .AddProvider(new FileLoggerProvider(LogPath))
                ;
            });
            ILogger logger = loggerFactory.CreateLogger<App>();

            services.AddSingleton<ILogger>(logger);
            #endregion


            var provider = services.BuildServiceProvider();
            MainWindow mainWindow = provider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
