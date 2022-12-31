using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportToCsv<TData>(IEnumerable<TData> ExportDtos);
    }
    
}
