




using System.Linq.Expressions;

namespace CPTool.Interfaces
{


    public interface IRepository<T> where T :  IAuditableEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        T UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
