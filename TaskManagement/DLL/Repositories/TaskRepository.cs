using DLL.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class TaskRepository : BaseRepository<MyTask>
    {
        public TaskRepository(TasksContext tasksContext) : base(tasksContext) { }
    }
}
