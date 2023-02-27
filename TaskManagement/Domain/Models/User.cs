using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhotoPath { get; set; }
        public string EMail { get; set; }
        public bool IsAdmin { get; set; }
        public IReadOnlyCollection<MyTask> MyTasks { get; set; }
    }
}
