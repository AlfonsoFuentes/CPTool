namespace CPTool.ApplicationCQRS.Contracts.Infrastructure
{
    public interface IPDFService
    {
        Task<byte[]> ExportToPDF<TData>(IEnumerable<TData> ExportDtos, Dictionary<string, Func<TData, object?>> mappers, string sheetName = "Sheet1");
    }
    
}
