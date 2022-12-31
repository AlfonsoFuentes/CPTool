using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Commands.Delete
{
    public class DeletePurchaseOrderCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
