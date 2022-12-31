namespace CPTool.ApplicationCQRS.Features.SignalTypes.Queries.ExportCSV
{
    public class SignalTypeExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}