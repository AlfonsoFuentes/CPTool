namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.ExportCSV
{
    public class PurchaseOrderItemExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}