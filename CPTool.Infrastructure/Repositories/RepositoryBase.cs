using CPtool.ExtensionMethods;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseDomainModel
    {
        protected readonly TableContext dbcontext;

        public RepositoryBase(TableContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
     
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbcontext.Set<T>().Where(predicate).ToListAsync();
        }

        public void GetTracker()
        {
            //dbcontext.ChangeTracker.DetectChanges();
            var traked = dbcontext.ChangeTracker.DebugView.LongView;
            foreach (var entry in dbcontext.ChangeTracker.Entries<BaseDomainModel>())
            {
                var state = entry.State;
            }
        }
        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
               
                IQueryable<T> query = dbcontext.Set<T>();
            
                query = Query(query);
                var retorno = await query.ToListAsync();
                return retorno;
            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }
            return null!;
        }
        public async Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            List<Expression<Func<T, object>>> includes = null!,
            bool disableTracking = true)
        {
            IQueryable<T> query = dbcontext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query =
                    includes.Aggregate(query, (current, include) =>
                current.Include(include));

            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            

           var result = await dbcontext.Set<T>().FindAsync(id);
            return result!;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = dbcontext.Set<T>();
            return await query.AnyAsync(filter);
        }

        public void Add(T entity)
        {
            dbcontext.Add(entity);
        }

        public void Update(T entity)
        {
            try
            {

                dbcontext.Set<T>().Attach(entity);
                dbcontext.Entry(entity).State = EntityState.Modified;

            }
            catch (Exception ex)
            {
                string exm = ex.Message;
            }

        }

        public void Delete(T entity)
        {
            dbcontext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null!, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null!, bool includestring = false, bool disableTracking = true)
        {
            IQueryable<T> query = dbcontext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includestring) query = Query(query);


            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            var retorno = await query.ToListAsync();
            return retorno;
        }
        //Query Include de first relationship of the Entity <T>,
        //If the objects inside de <T> Entity has more other relations, must be include via IrepositoryEntity overload IRepository<T>
        IQueryable<T> Query(IQueryable<T> table)
        {
            var query = table!.AsQueryable();
            var navigations = dbcontext.Model.FindEntityType(typeof(T))!
                     .GetDerivedTypesInclusive()
                     .SelectMany(type => type.GetNavigations())
                     .Distinct();

            foreach (var property in navigations)
            {
                query = query.Include(property.Name);
                var entity = property.DeclaringEntityType;


            }
            return query;
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await dbcontext.Set<T>().FirstOrDefaultAsync(predicate))!;
        }
    }
}
//public async  Task<IQueryable<T>> GetFilteredList(QueryFilter query)
//{
//    var items = dbcontext.Set<T>().AsQueryable();

//    if (query != null)
//    {
//        if (!string.IsNullOrEmpty(query.Expand))
//        {
//            var propertiesToExpand = query.Expand.Split(',');
//            foreach (var p in propertiesToExpand)
//            {
//                items = items.Include(p.Trim());
//            }
//        }

//        if (!string.IsNullOrEmpty(query.Filter))
//        {
//            if (query.FilterParameters != null)
//            {
//                items = items.Where(query.Filter, query.FilterParameters);
//            }
//            else
//            {
//                items = items.Where(query.Filter);
//            }
//        }

//        if (!string.IsNullOrEmpty(query.OrderBy))
//        {
//            items = items.OrderBy(query.OrderBy);
//        }

//        if (query.Skip.HasValue)
//        {
//            items = items.Skip(query.Skip.Value);
//        }

//        if (query.Top.HasValue)
//        {
//            items = items.Take(query.Top.Value);
//        }
//    }



//    return await Task.FromResult(items);
//}


