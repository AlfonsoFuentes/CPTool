

namespace CPTool.Implementations
{
    //public class Repository<TEntity> : IRepository<TEntity>
    // where TEntity : class, IAuditableEntity, new()
    //{
    //    private readonly TableContext _dbContext;

    //    public Repository(TableContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public async Task<IEnumerable<TEntity>> GetAll()
    //    {
    //        return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    //    }
    //    public async Task<TEntity> GetById(int id)
    //    {
    //        return await _dbContext.Set<TEntity>().FindAsync(id)!;
    //    }
    //    public async Task Create(TEntity entity)
    //    {
    //        await _dbContext.Set<TEntity>().AddAsync(entity);
    //        await _dbContext.SaveChangesAsync();
    //    }

    //    public async Task Update(TEntity entity)
    //    {
    //        try
    //        {

    //            _dbContext.Set<TEntity>().Update(entity);
    //            await _dbContext.SaveChangesAsync();
    //        }
    //        catch(Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }
            
    //    }

    //    public async Task Delete(int id)
    //    {
    //        var entity = await GetById(id);
    //        _dbContext.Set<TEntity>().Remove(entity);
    //        await _dbContext.SaveChangesAsync();
    //    }
    //    public async Task<bool> Any(Expression<Func<TEntity, bool>> filter = null!)
    //    {
    //        var all = await GetAll();
    //        //var result = all?.FirstOrDefault(filter);
    //        //if (result == null) return false;

    //        return true;
    //    }
    //}

    //public class Repository<T> : IRepository<T> where T : AuditableEntity/*,IDisposable*/
    //{
    //    private readonly TableContext _dbContext;
    //    private DbSet<T>? table = null;
    //    public Repository(TableContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //        table = _dbContext.Set<T>();
    //    }

    //    public async Task<IEnumerable<T>> GetAsync(
    //        Expression<Func<T, bool>> filter = null!,
    //        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!)
    //    {
    //        IQueryable<T> query = Query(true)!;

    //        if (filter != null)
    //        {
    //            query = query.Where(filter);
    //        }



    //        if (orderBy != null)
    //        {
    //            return await orderBy(query).ToListAsync();
    //            //return await orderBy(query).AsNoTracking().ToListAsync();
    //        }
    //        else
    //        {
    //            return await query.ToListAsync();
    //            //return await query.AsNoTracking().ToListAsync();
    //        }
    //    }

    //    public async Task<IEnumerable<T>> GetAllAsync()
    //    {

    //        try
    //        {
    //            var retorno1 = Query(true);
    //            var retorno = await retorno1.ToListAsync();
    //            //var retorno = await retorno1.AsNoTracking().ToListAsync();
    //            return retorno;
    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }
    //        return null!;
    //    }
    //    IQueryable<T> Query(bool eager = false)
    //    {
    //        var query = table!.AsQueryable();
    //        if (eager)
    //        {
    //            var navigations = _dbContext.Model.FindEntityType(typeof(T))!
    //                .GetDerivedTypesInclusive()
    //                .SelectMany(type => type.GetNavigations())
    //                .Distinct();

    //            foreach (var property in navigations)
    //            {
    //                query = query.Include(property.Name);

    //            }

    //        }
    //        return query;
    //    }
    //    public async Task<T> AddAsync(T entity)
    //    {
    //        try
    //        {

    //            await table!.AddAsync(entity);
    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }

    //        return entity;
    //    }
    //    public T Update(T entity)
    //    {
    //        var changetracker = _dbContext.ChangeTracker.DebugView.ShortView;
    //        try
    //        {
    //            var state = _dbContext.Entry(entity).State;
    //            if(state== EntityState.Detached)
    //            {
    //                GetStates();
    //            }

    //            table!.Attach(entity);
    //           _dbContext.Entry(entity).State = EntityState.Modified;
    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }

    //        return entity;



    //    }
    //    void GetStates()
    //    {
    //        foreach (var entry in _dbContext.ChangeTracker.Entries<IAuditableEntity>().ToList())
    //        {
    //            switch (entry.State)
    //            {
    //                case EntityState.Added:

    //                    break;

    //                case EntityState.Modified:


    //                    break;

    //            }
    //        }
    //    }
    //    public void Delete(object id)
    //    {
    //        T entityToDelete = table!.Find(id)!;
    //        Delete(entityToDelete);
    //    }

    //    public void Delete(T entity)
    //    {
    //        try
    //        {
    //            if (_dbContext.Entry(entity).State == EntityState.Detached)
    //            {
    //                table!.Attach(entity);
    //            }
    //            table!.Remove(entity);

    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }


    //    }

    //    public async Task<T> GetByIdAsync(int itemId/*, bool eager = false*/)
    //    {
    //        var entity2= await table!.FindAsync(itemId);

    //        var entity=await Query(true).AsNoTracking().FirstAsync(i => i.Id == itemId);
    //        if (entity != null)
    //        {
    //            try
    //            {
    //                var state2 = _dbContext.Entry<T>(entity!).State;
    //                var state = _dbContext.Entry(entity).State;
    //                if (state == EntityState.Detached)
    //                {
    //                    _dbContext.Entry(entity).State = EntityState.Detached;
    //                }
    //            }
    //            catch(Exception ex)
    //            {
    //                string exm = ex.Message;
    //            }


    //        }

    //        return entity2!;

    //    }
    //    public async Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    //    {
    //        return await _dbContext
    //            .Set<T>()
    //            .Skip((pageNumber - 1) * pageSize)
    //            .Take(pageSize).ToListAsync();
    //        //return await _dbContext
    //        //    .Set<T>()
    //        //    .Skip((pageNumber - 1) * pageSize)
    //        //    .Take(pageSize).AsNoTracking().ToListAsync();
    //    }



    //    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!)
    //    {

    //        var result=await FirstOrDefaultAsync(filter);
    //        if(result == null) return false;

    //        return true;
    //    }

    //    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    //    {
    //        T? result = null!;
    //        try
    //        {
    //            result = await Query(true).AsNoTracking().FirstOrDefaultAsync(predicate)!;
    //            if(result!=null)
    //            {
    //                var state2 = _dbContext.Entry<T>(result!).State;
    //                var state = _dbContext.Entry(result).State;
    //                if (state == EntityState.Detached)
    //                {
    //                    _dbContext.Entry(result).State = EntityState.Detached;
    //                }
    //            }


    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //        }
    //        return result!;
    //    }
    //    private bool _disposed = false;
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!_disposed)
    //        {
    //            if (disposing)
    //            {
    //                if (_dbContext != null)
    //                {
    //                    _dbContext.Dispose();
    //                }
    //            }

    //            _disposed = true;
    //        }
    //    }

    //    //public void Dispose()
    //    //{
    //    //    //Dispose(true);
    //    //    //GC.SuppressFinalize(this);
    //    //}

    //}
}
