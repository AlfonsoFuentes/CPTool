using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.Domain.Common;
using CPToolCQRS.Infrastructure.Persistence;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace CPTool.PersistenceCQRS.Repositories
{

    public class CommandRepository<T> : ICommandRepository<T> where T : AuditableEntity
    {
        protected readonly TableContext _dbContext;

        public CommandRepository(TableContext dbContext)
        {
            _dbContext = dbContext;
            QueryList = _dbContext.Set<T>()!
                .AsQueryable()
                .AsNoTracking()
                .AsSplitQuery();
            QueryDialog = _dbContext.Set<T>()!
               .AsQueryable()
               .AsNoTracking()
               .AsSplitQuery();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);


            return entity;
        }
        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbContext.Set<T>().FirstOrDefaultAsync(predicate))!;
        }
        public Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }
        public async Task<T?> FindAsync(int id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);


            return t;
        }

        public async Task<bool> IsPropertyUnique(int id, string PropertyName, string Value)
        {

            var list = await _dbContext.Set<T>().ToListAsync();

            foreach (var row in list)
            {
                var Identifier = row!.GetType()!.GetProperty("Id")!.GetValue(row)!.ToString();
                var name = row!.GetType().GetProperty(PropertyName)!.GetValue(row)!.ToString();
                if (name == Value && Identifier != id.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public virtual IQueryable<T> QueryList { get; set; }
        public virtual IQueryable<T> QueryDialog { get; set; }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var query = QueryList;
            if (predicate != null)
                query = QueryList.Where(predicate);

            return await query!.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            var query = QueryList;
            if (predicate != null)
                query = QueryList.Where(predicate);
            if (orderBy != null)
                return await orderBy(query!).ToListAsync();

            return await query!.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            var query = QueryList;

            if (orderBy != null)
                return await orderBy(query!).ToListAsync();

            return await query!.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await QueryList!.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var query = QueryDialog;
            if (QueryDialog != null)
                query = QueryDialog.Where(x => x.Id == id);

            return await query!.FirstOrDefaultAsync();
        }
        public async Task<T?> GetByIdFromListAsync(int id)
        {
            var query = QueryList;
            if (QueryList != null)
                query = QueryList.Where(x => x.Id == id);

            return await query!.FirstOrDefaultAsync();
        }
    }
    //public class BaseRepository<T> : IAsyncRepository<T> where T : AuditableEntity
    //{
    //    protected readonly TableContext _dbContext;

    //    protected DbSet<T> tableSet => _dbContext.Set<T>();
    //    public BaseRepository(TableContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public async Task<T?> FindAsync(int id)
    //    {
    //        T? t = await _dbContext.Set<T>().FindAsync(id);


    //        return t;
    //    }
    //    public virtual async Task<T?> GetByIdAsync(int id)
    //    {
    //        var query = _dbContext.Set<T>().Where(x => x.Id == id).AsQueryable().AsNoTrackingWithIdentityResolution();
    //        query = Query(query);
    //        var result = await query.FirstOrDefaultAsync();

    //        return result;
    //    }


    //    //public virtual async Task<IReadOnlyList<T>> GetAllAsync(bool Includes = false)
    //    //{
    //    //    return await GetAllAsync(null!, null!, Includes);
    //    //}

    //    //public virtual async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool Includes = false)
    //    //{
    //    //    return await GetAllAsync(predicate, null!, Includes);
    //    //}
    //    //public async Task<IReadOnlyList<T>> GetAllAsync(IQueryable<T> query, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    //    //{
    //    //    if (orderBy != null)
    //    //        return await orderBy(query).ToListAsync();

    //    //    return await GetAllAsync(query);

    //    //}
    //    //public virtual async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    //    //{
    //    //    IQueryable<T> query = _dbContext.Set<T>().AsQueryable().AsNoTrackingWithIdentityResolution();
    //    //    if (predicate != null)
    //    //        query = query.Where(predicate);

    //    //    if (orderBy != null)
    //    //        return await orderBy(query).ToListAsync();

    //    //    return await GetAllAsync(query);
    //    //}
    //    //public async Task<IReadOnlyList<T>> GetAllAsync(IQueryable<T> query)
    //    //{
    //    //    var result = await query.ToListAsync();
    //    //    return null!;
    //    //}

    //    IQueryable<T> Query(IQueryable<T> query)
    //    {
    //        var navigations = _dbContext.Model.FindEntityType(typeof(T))!
    //              .GetDerivedTypesInclusive()
    //             .SelectMany(type => type.GetNavigations())
    //             .Distinct();

    //        foreach (var property in navigations)
    //        {
    //            query = query.Include(property.Name).AsSplitQuery();



    //        }


    //        return query;
    //    }
    //    // public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int size, int page)
    //    // {
    //    //     return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    //    // }
    //    // public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate,
    //    // Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int size, int page,
    //    // bool Includes = false)

    //    // {

    //    //     var query = _dbContext.Set<T>().Skip((page - 1) * size).Take(size);
    //    //     return await GetAllAsync(query, predicate, orderBy, Includes);

    //    // }
    //    // public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(
    //    //     Expression<Func<T, bool>> predicate,
    //    //int size, int page,
    //    // bool Includes = false)

    //    // {
    //    //     var query = _dbContext.Set<T>().Skip((page - 1) * size).Take(size);
    //    //     return await GetAllAsync(query, predicate, null!, Includes);

    //    // }
    //    public async Task<T> AddAsync(T entity)
    //    {
    //        await _dbContext.Set<T>().AddAsync(entity);


    //        return entity;
    //    }
    //    public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    //    {
    //        return (await _dbContext.Set<T>().FirstOrDefaultAsync(predicate))!;
    //    }
    //    public Task UpdateAsync(T entity)
    //    {
    //        _dbContext.Set<T>().Attach(entity);
    //        _dbContext.Entry(entity).State = EntityState.Modified;

    //        return Task.CompletedTask;
    //    }

    //    public Task DeleteAsync(T entity)
    //    {
    //        _dbContext.Set<T>().Remove(entity);

    //        return Task.CompletedTask;
    //    }


    //    public virtual async Task<bool> IsNameUnique(int id, string name)
    //    {

    //        if (id == 0)
    //        {
    //            return await tableSet!.Where(x => x.Name == name).AnyAsync();
    //        }
    //        return await tableSet!.Where(x => x.Id != id && x.Name == name).AnyAsync();
    //    }


    //}
}
