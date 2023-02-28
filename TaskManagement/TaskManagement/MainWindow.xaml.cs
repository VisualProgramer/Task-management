using BLL.Services;
using Domain.Models;
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

namespace TaskManagement
{
    //var result = _userService.RemoveAsync(int.Parse(txtId.Text)).Result; Why here i must write Result?
    //Method UpdateAsync don't working WITHOUT!!! tasksContext.Entry(entity).State = EntityState.Detached; IN CreatAsync and in UpdateAsync

    public partial class MainWindow : Window
    {
        private readonly UserService _userService;

        public MainWindow(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var result = await _userService.CreateAsync(new User()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Login = txtLogin.Text,
                Password = txtPassword.Text
            });


            txtError.Text = result.Message;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = await _userService.UpdateAsync(new User()
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Login = txtLogin.Text,
                Password = txtPassword.Text
            });

            txtError.Text=result.Message;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           var result = await _userService.RemoveAsync(int.Parse(txtId.Text));

            txtError.Text = result.Message;
        }
    }
}
