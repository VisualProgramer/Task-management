using BLL.Services;
using DLL.Context;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskManagement.Views;

namespace TaskManagement
{
    public partial class App : Application
    {
        public static ServiceProvider provider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            provider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<TasksContext>(option =>
            {
                option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TasksManagement;Integrated Security=True;");     
            });
            services.AddTransient<MainWindow>();
            services.AddTransient<LoginView>();
            services.AddTransient<RegistrationView>();

            services.AddTransient<UserRepository>();
            services.AddTransient<UserService>();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginView = provider.GetService<LoginView>();
            loginView.Show();
        }
    }
}
