using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetDetail
{
    public class GetPurchaseOrderDetailQuery : IRequest<CommandPurchaseOrder>
    {
        public int Id { get; set; }
    }
}
