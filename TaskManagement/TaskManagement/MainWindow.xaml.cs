using BLL.Services;
using Domain.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagement.Views;

namespace TaskManagement
{
    //var result = _userService.RemoveAsync(int.Parse(txtId.Text)).Result; Why here i must write Result?
    //Method UpdateAsync don't working WITHOUT!!! tasksContext.Entry(entity).State = EntityState.Detached; IN CreatAsync and in UpdateAsync
    //var result = await _userService.FindByConditionAsync(x => x.EMail == txtEmail.Text && x.Password == txtPass.Password) return Collection and i can Get First in the row
    //RegistrationView == null in LoginView when I click on Button Registration

    public partial class MainWindow : Window
    {
        private readonly LoginView _loginView;

        public MainWindow(LoginView loginView)
        {
            InitializeComponent();
            _loginView = App.provider.GetService<LoginView>();
        }

        private void rbAddTasks_Checked(object sender, RoutedEventArgs e)
        {
            var _addTasks = App.provider.GetService<AddTasks>();

            ccAddTasks.Content = _addTasks;
        }
        private void rdMyTasks_Checked(object sender, RoutedEventArgs e)
        {
            var _tasksView = App.provider.GetService<TasksView>();

            ccAddTasks.Content = _tasksView;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            _loginView.Show();
            this.Close();
        }

    }
}
