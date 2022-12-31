namespace CPTool.ApplicationCQRS.Features.Takss.Queries.ExportCSV
{
    public class TaksExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}