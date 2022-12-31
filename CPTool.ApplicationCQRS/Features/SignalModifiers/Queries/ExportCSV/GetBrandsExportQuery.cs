using MediatR;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.ExportCSV
{
    public class GetSignalModifiersExportQuery : IRequest<SignalModifierExportFileVm>
    {
    }
}
