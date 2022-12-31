using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class PurchaseOrderItemCommandResponse : BaseResponse
    {
        public PurchaseOrderItemCommandResponse() : base()
        {

        }

        public CommandPurchaseOrderItem? PurchaseOrderItemObject { get; set; }
    }
}