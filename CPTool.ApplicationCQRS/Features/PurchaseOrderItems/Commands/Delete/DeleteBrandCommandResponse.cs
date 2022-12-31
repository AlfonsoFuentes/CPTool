using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Commands.Delete
{
    public class DeletePurchaseOrderItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
