namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.ExportCSV
{
    public class TaxCodeLDExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}