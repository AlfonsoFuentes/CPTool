namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.ExportCSV
{
    public class ProcessConditionExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}