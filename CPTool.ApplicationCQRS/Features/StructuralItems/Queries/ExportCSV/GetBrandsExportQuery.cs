using MediatR;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.ExportCSV
{
    public class GetStructuralItemsExportQuery : IRequest<StructuralItemExportFileVm>
    {
    }
}
