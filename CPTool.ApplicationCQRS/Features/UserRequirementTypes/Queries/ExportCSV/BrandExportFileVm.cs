namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.ExportCSV
{
    public class UserRequirementTypeExportFileVm
    {
        public string ExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}