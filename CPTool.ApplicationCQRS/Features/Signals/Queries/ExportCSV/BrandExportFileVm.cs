namespace CPTool.ApplicationCQRS.Features.Signals.Queries.ExportCSV
{
    public class SignalExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}