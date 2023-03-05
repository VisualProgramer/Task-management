using BLL.Services;
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
    public partial class TasksView : UserControl
    {
        private readonly TaskService _taskService;

        public TasksView(TaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;
            ShowAllTasks();
        }
        private async void ShowAllTasks ()
        {
            lvMyTasks.DataContext = await _taskService.GetAllAsync();
        }
    }
}
