using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TasksContext tasksContext;
        private DbSet<TEntity> _entities;

        protected DbSet<TEntity> Entities => _entities ??= tasksContext.Set<TEntity>();

        public BaseRepository(TasksContext tasksContext)
        {
            this.tasksContext = tasksContext;
        }

        public virtual async Task<OperationDetail> CreatAsync(TEntity entity)
        {
            try
            {
                await Entities.AddAsync(entity);
                await tasksContext.SaveChangesAsync();
                return new OperationDetail() { IsError = false, Message = "Created" };
            }
            catch (Exception ex)
            {
                return new OperationDetail() { IsError = true, Message = ex.Message, Exception = ex };
            }
        }
    }
}
