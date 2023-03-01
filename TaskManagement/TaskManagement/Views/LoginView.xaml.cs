using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;

namespace TaskManagement.Views
{
    public partial class LoginView : Window
    {
        private readonly UserService _userService;
        public LoginView(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton==Mouse.LeftButton)
            {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var result = await _userService.FindByConditionAsync(x => x.EMail == txtEmail.Text && x.Password == txtPass.Password);
            if (result.Any())
            {
                var mainWindow = App.provider.GetService<MainWindow>();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Inccorect data");
            }
        }
    }
}
