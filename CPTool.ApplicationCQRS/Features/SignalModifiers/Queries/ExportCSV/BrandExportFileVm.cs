namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.ExportCSV
{
    public class SignalModifierExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}