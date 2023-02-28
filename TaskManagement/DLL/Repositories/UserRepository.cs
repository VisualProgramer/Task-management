using DLL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    public class UserRepository : BaseRepository<User>,IRemoveRepository<User>
    {
        public UserRepository(TasksContext tasksContext) : base(tasksContext) { }

        public virtual async Task<OperationDetail> RemoveAsync(int entityId)
        {
            try
            {
                Entities.Remove(Entities.First(x => x.Id == entityId));
                await tasksContext.SaveChangesAsync();
                return new OperationDetail() { IsError = false, Message = "Removed" };
            }
            catch (Exception ex)
            {
                return new OperationDetail() { IsError = true, Message = ex.Message, Exception = ex };
            }
        }
    }
}
