namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.ExportCSV
{
    public class PipeDiameterExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}