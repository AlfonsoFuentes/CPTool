using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetDetail
{
    public class GetPurchaseOrderItemDetailQuery : IRequest<CommandPurchaseOrderItem>
    {
        public int Id { get; set; }
    }
}
