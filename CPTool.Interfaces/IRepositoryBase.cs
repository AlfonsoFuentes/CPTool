using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Interfaces
{
    public interface IRepositoryBase<T> where T : IAuditableEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        bool Any(Expression<Func<T, bool>> expression);
    }
    public interface IRepositoryBaseAsync<T>: IRepositoryBase<T> where T : IAuditableEntity
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        
    }
}
