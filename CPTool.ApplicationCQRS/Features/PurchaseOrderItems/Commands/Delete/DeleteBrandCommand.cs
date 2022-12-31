using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Commands.Delete
{
    public class DeletePurchaseOrderItemCommand : IRequest<DeletePurchaseOrderItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
