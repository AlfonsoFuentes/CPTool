using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Queries.ExportCSV
{
    public class GetTaxesItemsExportQuery : IRequest<TaxesItemExportFileVm>
    {
    }
}
