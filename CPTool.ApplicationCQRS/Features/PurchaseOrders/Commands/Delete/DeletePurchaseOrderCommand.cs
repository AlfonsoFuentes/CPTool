using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Commands.Delete
{
    public class DeletePurchaseOrderCommand : IRequest<DeletePurchaseOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}
