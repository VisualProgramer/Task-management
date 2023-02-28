using DLL.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<OperationDetail> CreateAsync(MyTask myTask)
        {
            return await _taskRepository.CreatAsync(myTask);
        }
        public async Task<OperationDetail> UpdateAsync(MyTask myTask)
        {
            return await _taskRepository.UpdateAsync(myTask);
        }
        public async Task<IReadOnlyCollection<MyTask>> FindByConditionAsync(Expression<Func<MyTask, bool>> expression)
        {
            return await _taskRepository.FindByConditionAsync(expression);
        }
        public async Task<IReadOnlyCollection<MyTask>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync();
        }
    }
}
