using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.ExportCSV
{
    public class GetPurchaseOrderItemsExportQuery : IRequest<PurchaseOrderItemExportFileVm>
    {
    }
}
