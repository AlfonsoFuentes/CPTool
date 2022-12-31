namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.ExportCSV
{
    public class PropertyPackageExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}