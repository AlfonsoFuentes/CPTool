using MediatR;

namespace CPTool.ApplicationCQRS.Features.Takss.Queries.ExportCSV
{
    public class GetTakssExportQuery : IRequest<TaksExportFileVm>
    {
    }
}
