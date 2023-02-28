using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IRemoveRepository<TEntity>
    {
        Task<OperationDetail> RemoveAsync(int entityId);
    }
}
