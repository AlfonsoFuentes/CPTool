namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.ExportCSV
{
    public class PipingItemExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}