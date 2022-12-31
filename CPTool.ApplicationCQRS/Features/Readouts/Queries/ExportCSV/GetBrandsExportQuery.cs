using MediatR;

namespace CPTool.ApplicationCQRS.Features.Readouts.Queries.ExportCSV
{
    public class GetReadoutsExportQuery : IRequest<ReadoutExportFileVm>
    {
    }
}
