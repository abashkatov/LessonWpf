using Microsoft.Extensions.DependencyInjection;
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

            var provider = services.BuildServiceProvider();
            MainWindow mainWindow = provider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
