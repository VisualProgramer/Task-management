using DLL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DLL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(TasksContext tasksContext) : base(tasksContext) { }
    }
}
