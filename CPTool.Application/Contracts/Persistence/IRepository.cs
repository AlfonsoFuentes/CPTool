

namespace CPTool.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            bool includestring = false,
            bool disableTracking = true);
        

        Task<T> GetByIdAsync(int id);

     
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

