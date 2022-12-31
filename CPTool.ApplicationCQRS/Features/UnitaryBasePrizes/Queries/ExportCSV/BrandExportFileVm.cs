namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.ExportCSV
{
    public class UnitaryBasePrizeExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}