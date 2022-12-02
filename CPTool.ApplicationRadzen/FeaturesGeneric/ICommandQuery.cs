using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.FeaturesGeneric
{
    public interface ICommandQuery<T> where T : EditCommand
    {
       
        string TableName { get; set; }
        Task<Result<int>> AddUpdate(T request);
        Task<IResult> Delete(int id);
        //Task ExportToCSV(QueryFilter query = null!, string filename = null!);
        //Task ExportToExcel(QueryFilter query = null!, string filename = null!);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Reset();
    }
    
}