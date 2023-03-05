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

namespace TaskManagement.Views
{
    public partial class AddTasks : UserControl
    {
        private readonly UserService _userService;
        private readonly TaskService _taskService;

        public AddTasks(UserService userService, TaskService taskService)
        {
            InitializeComponent();
            _userService = userService;
            _taskService = taskService;
            ShowAll();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            popAddTask.IsOpen = false;
            popAddTask.PlacementTarget = sender as Button;
            popAddTask.IsOpen = true;

            popAddTask.Tag = (sender as Button).Tag;
        }
        private async void btnDaleteUser_Click(object sender, RoutedEventArgs e)
        {
            var Id = int.Parse((sender as Button).Tag.ToString());
            await _userService.RemoveAsync(Id);
            ShowAll();
        }
        private async void ShowAll()
        {
            lvUsers.DataContext = await _userService.GetAllAsync();
        }
        private async void imgPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var userId = int.Parse((sender as Image).Tag.ToString());
            lvTasks.DataContext = await _taskService.FindByConditionAsync(x => x.ExecutorId == userId);
            popShowTasks.IsOpen = false;
            popShowTasks.PlacementTarget = sender as Image;
            popShowTasks.IsOpen = true;
        }
        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var UserId = int.Parse(popAddTask.Tag.ToString());

            var newTask = new MyTask()
            {
                Description = txtDescription.Text,
                Priority = int.Parse(txtPriority.Text),
                ExecutorId = UserId,
                CreationDate = DateTime.Now,
                IsExecuted = false
            };

            await _taskService.CreateAsync(newTask);
            popAddTask.IsOpen = false;
        }
        private async void borderIsExecuted_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Border).Background = new SolidColorBrush(Colors.Black);
            var taskId = int.Parse((sender as Border).Tag.ToString());

            var updateTask = await _taskService.FindByConditionAsync(x => x.Id == taskId);
            updateTask.First().IsExecuted = true;

            await _taskService.UpdateAsync(updateTask.First());
        }
    }
}
