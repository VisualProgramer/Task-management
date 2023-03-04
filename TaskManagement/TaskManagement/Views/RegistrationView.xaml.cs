using BLL.Services;
using Domain.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace TaskManagement.Views
{
    public partial class RegistrationView : UserControl
    {
        private readonly UserService _userService;

        public RegistrationView(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Password = txtPassword.Text,
                EMail = txtEmail.Text,
                PhotoPath = imgPhoto.Source.ToString()                
            };

            _userService.CreateAsync(newUser);
            this.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility= Visibility.Collapsed;
        }

        private void imgPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            imgPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        }
    }
}
