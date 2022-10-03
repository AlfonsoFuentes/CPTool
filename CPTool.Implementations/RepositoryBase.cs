using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Implementations
{
   
    //public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : AuditableEntity
    //{
    //    protected TableContext RepositoryContext { get; set; }

    //    public RepositoryBase(TableContext repositoryContext)
    //    {
    //        this.RepositoryContext = repositoryContext;
    //    }
    //    IQueryable<T> Query()
    //    {
    //        var query2 = this.RepositoryContext.Set<T>()!.AsQueryable();
    //        var query = query2.AsNoTracking();
    //        var navigations = RepositoryContext.Model.FindEntityType(typeof(T))!
    //                .GetDerivedTypesInclusive()
    //                .SelectMany(type => type.GetNavigations())
    //                .Distinct();

    //        foreach (var property in navigations)
    //        {
    //            query = query.Include(property.Name).AsNoTracking();

    //        }
    //        var query3 = query.AsNoTracking();
    //        return query3;
    //    }
    //    public IQueryable<T> FindAll2()
    //    {
    //        return Query();
    //    }
    //    public IQueryable<T> FindAll()
    //    {
    //        return this.RepositoryContext.Set<T>().AsNoTracking();
    //    }

    //    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    //    {
    //        return this.RepositoryContext.Set<T>().AsNoTracking()
    //            .Where(expression).AsNoTracking();
    //    }

    //    public void Create(T entity)
    //    {
    //        this.RepositoryContext.Set<T>().Add(entity);
    //    }

    //    public void Update(T entity)
    //    {
    //        try
    //        {
    //            var changetracker = RepositoryContext.ChangeTracker.DebugView.ShortView;
    //            this.RepositoryContext.Set<T>().Update(entity);
    //        }
    //        catch(Exception ex)
    //        {
    //            var changetracker = RepositoryContext.ChangeTracker.DebugView.ShortView;
    //            string exm = ex.Message;
    //        }
            
    //    }

    //    public void Delete(T entity)
    //    {
    //        this.RepositoryContext.Set<T>().Remove(entity);
    //    }
    //    public bool Any(Expression<Func<T, bool>> expression)
    //    {
    //        return this.RepositoryContext.Set<T>().AsNoTracking()
    //        .Any(expression);
    //    }
    //}

    //public class RepositoryBaseAsync<T> : RepositoryBase<T>, IRepositoryBaseAsync<T> where T : AuditableEntity
    //{


    //    public RepositoryBaseAsync(TableContext repositoryContext) : base(repositoryContext)
    //    {

    //    }



    //    public async Task<IEnumerable<T>> FindAllAsync()
    //    {
    //        return await FindAll().AsNoTracking().ToListAsync();
    //    }

    //    public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
    //    {
    //        return await FindByCondition(expression).ToListAsync();
    //    }

    //    public async Task<T> GetByIdAsync(int id)
    //    {
    //        var retorno = await this.RepositoryContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);// await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
    //        return retorno!;
    //    }
    //}
}
