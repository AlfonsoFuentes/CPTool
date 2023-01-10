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
using System.Diagnostics;
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

        //public async Task<bool> IsPropertyUnique(int id, string PropertyName, string Value)
        //{

        //    var list = await _dbContext.Set<T>().ToListAsync();

        //    foreach (var row in list)
        //    {
        //        var Identifier = row!.GetType()!.GetProperty("Id")!.GetValue(row)!.ToString();
        //        var name = row!.GetType().GetProperty(PropertyName)!.GetValue(row)!.ToString();
        //        if (name == Value && Identifier != id.ToString())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public virtual IQueryable<T> QueryList { get; set; }
        public virtual IQueryable<T> QueryDialog { get; set; }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var query = QueryList;
            if (predicate != null)
                query = QueryList.Where(predicate);

            var result = await query!.ToListAsync();
            stopwatch.Stop();
            Console.WriteLine($"GetAllAsync(predicate()) of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
            return result;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IReadOnlyList<T> result = null!;
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var query = QueryList;
            if (predicate != null)
                query = QueryList.Where(predicate);
            if (orderBy != null)
                result = await orderBy(query!).ToListAsync();
            else
                result = await query!.ToListAsync();
            stopwatch.Stop();
            Console.WriteLine($"GetAllAsync(predicate,orderby) of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
            return result;
        }
        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {

            return (await GetAllAsync(predicate)).Count > 0;
        }
    public async Task<IReadOnlyList<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        IReadOnlyList<T> result = null!;
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var query = QueryList;

        if (orderBy != null)
            result = await orderBy(query!).ToListAsync();
        else
            result = await query!.ToListAsync();
        stopwatch.Stop();
        Console.WriteLine($"GetAllAsync(orderby) of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
        return result;
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var result = await QueryList!.ToListAsync();
        stopwatch.Stop();
        Console.WriteLine($"GetAllAsync() of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
        return result;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var query = QueryDialog;
        if (QueryDialog != null)
            query = QueryDialog.Where(x => x.Id == id);

        var result = await query!.FirstOrDefaultAsync();
        stopwatch.Stop();
        Console.WriteLine($"GetByIdAsync(int id) of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
        return result;
    }
    public async Task<T?> GetByIdFromListAsync(int id)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var query = QueryList;
        if (QueryList != null)
            query = QueryList.Where(x => x.Id == id);
        var result = await query!.FirstOrDefaultAsync();
        stopwatch.Stop();
        Console.WriteLine($"GetByIdFromListAsync(int id) of {typeof(T).Name} elapsed time: {stopwatch.ElapsedMilliseconds}");
        return result;
    }
}
}
