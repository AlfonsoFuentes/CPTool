namespace CPTool.ApplicationCQRS.Features.Readouts.Queries.ExportCSV
{
    public class ReadoutExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}