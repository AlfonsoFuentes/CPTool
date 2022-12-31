using MediatR;

namespace CPTool.ApplicationCQRS.Features.Signals.Queries.ExportCSV
{
    public class GetSignalsExportQuery : IRequest<SignalExportFileVm>
    {
    }
}
