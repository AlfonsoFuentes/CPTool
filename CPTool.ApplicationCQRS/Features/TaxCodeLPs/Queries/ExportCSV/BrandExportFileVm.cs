namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.ExportCSV
{
    public class TaxCodeLPExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}