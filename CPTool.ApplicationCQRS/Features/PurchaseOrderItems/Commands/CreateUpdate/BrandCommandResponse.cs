using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class PurchaseOrderItemCommandResponse : BaseResponse<CommandPurchaseOrderItem>
    {
        public PurchaseOrderItemCommandResponse() : base()
        {

        }
    }
}