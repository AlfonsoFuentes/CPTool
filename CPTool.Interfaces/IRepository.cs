




using System.Linq.Expressions;

namespace CPTool.Interfaces
{


    public interface IRepository<TEntity>
where TEntity : class, IAuditableEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update( TEntity entity);

        Task Delete(int id);
        Task<bool> Any(Expression<Func<TEntity, bool>> filter = null!);
    }
}
