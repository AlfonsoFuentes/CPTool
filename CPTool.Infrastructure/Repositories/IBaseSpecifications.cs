using System.Linq.Expressions;

namespace CPTool.Infrastructure.Repositories
{
    public interface IBaseSpecifications<T>
    {
        Expression<Func<T, bool>> FilterCondition { get; }
        Expression<Func<T, object>> GroupBy { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        void AddInclude(Expression<Func<T, object>> includeExpression);
        void ApplyGroupBy(Expression<Func<T, object>> groupByExpression);
        void ApplyOrderBy(Expression<Func<T, object>> orderByExpression);
        void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression);
        void SetFilterCondition(Expression<Func<T, bool>> filterExpression);
    }
}