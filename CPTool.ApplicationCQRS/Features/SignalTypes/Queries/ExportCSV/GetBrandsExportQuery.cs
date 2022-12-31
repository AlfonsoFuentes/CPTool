using MediatR;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Queries.ExportCSV
{
    public class GetSignalTypesExportQuery : IRequest<SignalTypeExportFileVm>
    {
    }
}
