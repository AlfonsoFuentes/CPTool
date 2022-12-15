using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Generic
{
    public interface ICommandQuery<T> where T : EditCommand
    {
        string FileName { get; set; }
        string TableName { get; set; }
        Task<IResult> AddUpdate(T request);
        Task<IResult> Delete(int id);
      
        Task<Result<QueryExcel<T>>> ExportToExcel(List<T> elements, string filename = "");
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> predicate);
 
        Task<T> GetById(int id);
        void Reset();
        List<T> Search(string searched, List<T> result);
    }

}