




namespace CPTool.Persistence.Persistence
{
    public interface IRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
      
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> filter = null!);
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            bool includestring = false,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null!, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
           List<Expression<Func<T, object>>> includes = null!, bool disableTracking = true);


        Task<T> GetByIdAsync(int id);
      
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
 

    }
}

