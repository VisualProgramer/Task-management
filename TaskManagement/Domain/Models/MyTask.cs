using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsExecuted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public User Executor { get; set; }
        public int ExecutorId { get; set; }
    }
}
