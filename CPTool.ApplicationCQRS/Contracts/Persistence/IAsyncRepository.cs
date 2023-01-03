using CPTool.Domain.Common;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRS.Contracts.Persistence
{

    public interface ICommandRepository<T> where T : AuditableEntity
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<bool> IsPropertyUnique(int id, string PropertyName, string Value );
        Task<T?> FindAsync(int id);
     
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> QueryList { get; set; }
        IQueryable<T> QueryDialog { get; set; }
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IReadOnlyList<T>> GetAllAsync( Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdFromListAsync(int id);
    }
    //public interface IQueryRepository<T> where T : AuditableEntity
    //{
    //    IQueryable<T> Query { get; set; }
      
    //    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    //    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);

    //    Task<IReadOnlyList<T>> GetAllAsync();
    //    Task<T?> GetByIdAsync(int id);
    //}
    //public interface IAsyncRepository<T> where T : AuditableEntity
    //{
    //    Task<T?> GetByIdAsync(int id);

    //    //Task<IReadOnlyList<T>> GetAllAsync(bool Includes = false);
    //    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    //    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    //    Task<IReadOnlyList<T>> GetAllAsync(IQueryable<T> query);
    //    Task<IReadOnlyList<T>> GetAllAsync();
    //    Task<T> AddAsync(T entity);
    //    Task UpdateAsync(T entity);
    //    Task DeleteAsync(T entity);
      
    //    Task<bool> IsNameUnique(int id,string name);
    //    Task<T?> FindAsync(int id);

    //    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
       
    //    //Task<IReadOnlyList<T>> GetPagedReponseAsync(int size, int page);

    //    //Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int size, int page, bool Includes = false);
    //    //Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int size, int page, bool Includes = false);
    //}
}
