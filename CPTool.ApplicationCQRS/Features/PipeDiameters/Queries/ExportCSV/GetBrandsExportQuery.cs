using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.ExportCSV
{
    public class GetPipeDiametersExportQuery : IRequest<PipeDiameterExportFileVm>
    {
    }
}
