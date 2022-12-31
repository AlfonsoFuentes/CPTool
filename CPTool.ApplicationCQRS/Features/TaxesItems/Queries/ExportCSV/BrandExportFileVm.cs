namespace CPTool.ApplicationCQRS.Features.TaxesItems.Queries.ExportCSV
{
    public class TaxesItemExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}