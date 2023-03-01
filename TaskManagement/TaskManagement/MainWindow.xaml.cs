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
    //var result = await _userService.FindByConditionAsync(x => x.EMail == txtEmail.Text && x.Password == txtPass.Password) return Collection and i can Get First in the row
    public partial class MainWindow : Window
    {
        public MainWindow(UserService userService)
        {
            InitializeComponent();
        }
    }
}
