namespace CPTool.ApplicationCQRS.Features.Suppliers.Queries.ExportCSV
{
    public class SupplierExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}