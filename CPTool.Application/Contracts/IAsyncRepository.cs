using System.Linq.Expressions;

namespace CPTool.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);

        Task<bool> IsNameUnique(string name);
        Task<bool> Any(Expression<Func<T, bool>> filter = null!);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
