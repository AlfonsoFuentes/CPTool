using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Reflection;

namespace CPTool.Implementations
{
    public class Repository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly TableContext _dbContext;

        public Repository(TableContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            try
            {

                await _dbContext.AddAsync(entity);
            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }

            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            try
            {

                _dbContext.Remove(entity);

            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }

            return Task.CompletedTask;
        }
        public virtual IQueryable<T> Query(bool eager = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (eager)
            {
                var navigations = _dbContext.Model.FindEntityType(typeof(T))!
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigations)
                {
                    query = query.Include(property.Name);

                }

            }
            return query;
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> retorno = new();
            try
            {
                var retorno1 = Query(true);
                //retorno = retorno1.ToList();
                retorno = await retorno1.ToListAsync();
            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }
            return retorno;
        }


        public async Task<T> GetByIdAsync(int itemId/*, bool eager = false*/)
        {
            return await Query(true).FirstAsync(i => i.Id == itemId);
        }
        public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public T UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().First(x => x == entity)!;
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();
            return await query.AnyAsync(filter);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            T? result = null!;
            try
            {
                var query = _dbContext.Set<T>();
                result = await Query(true).FirstOrDefaultAsync(predicate)!;
            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }
            return result!;
        }
    }
}
