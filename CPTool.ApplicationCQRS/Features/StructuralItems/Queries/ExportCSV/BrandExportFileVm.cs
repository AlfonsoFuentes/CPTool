namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.ExportCSV
{
    public class StructuralItemExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}