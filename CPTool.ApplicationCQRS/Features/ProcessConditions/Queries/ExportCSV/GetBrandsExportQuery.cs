using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.ExportCSV
{
    public class GetProcessConditionsExportQuery : IRequest<ProcessConditionExportFileVm>
    {
    }
}
