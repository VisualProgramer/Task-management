using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IRepository <TEntity>
    {
        Task<OperationDetail> CreatAsync(TEntity entity);
        Task<OperationDetail> UpdateAsync(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    }
}
