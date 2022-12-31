using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetList
{
    public class GetPurchaseOrderItemsListQuery : IRequest<List<CommandPurchaseOrderItem>>
    {
        public int MWOItemId { get; set; }
    }
}
