using MediatR;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Queries.ExportCSV
{
    public class GetTestingItemsExportQuery : IRequest<TestingItemExportFileVm>
    {
    }
}
