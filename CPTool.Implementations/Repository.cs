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
                //await _dbContext.Set<T>().AddAsync(entity);
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
                //_dbContext.Set<T>().Remove(entity);
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
                    query = query.Include(property.Name).AsNoTracking();
                    
                }
                   
            }
            return query;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            //var retorno =  _dbContext
            //    .Set<T>().ToIncludeEntities();
            var retorno3 = await Query(true).ToListAsync();
            //var retorno2 = await _dbContext.Set<T>().ToListAsync();
            return  retorno3.AsQueryable();
        }

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    var retorno = await _dbContext.Set<T>().FindAsync(id)!;
        //    //var retornoList = await GetAllAsync();
        //    //var retorno = retornoList.FirstOrDefault(x=>x.Id==id);
        //    return retorno!;
        //}
        public async Task<T?> GetByIdAsync(int itemId/*, bool eager = false*/)
        {
            return await Query(true).FirstOrDefaultAsync(i => i.Id == itemId);
        }
        public async Task<IQueryable<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return  _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public T UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id)!;
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
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
            return result;
        }
    }
}
