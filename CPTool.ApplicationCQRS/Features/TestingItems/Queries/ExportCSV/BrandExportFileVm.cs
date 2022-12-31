namespace CPTool.ApplicationCQRS.Features.TestingItems.Queries.ExportCSV
{
    public class TestingItemExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}