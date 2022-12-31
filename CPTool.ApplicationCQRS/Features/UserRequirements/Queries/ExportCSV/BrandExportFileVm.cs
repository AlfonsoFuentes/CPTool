namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.ExportCSV
{
    public class UserRequirementExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}