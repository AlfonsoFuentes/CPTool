using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.ExportCSV
{
    public class GetPipingItemsExportQuery : IRequest<PipingItemExportFileVm>
    {
    }
}
