using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate
{
    public class PurchaseOrderCommandResponse : BaseResponse<CommandPurchaseOrder>
    {
        public PurchaseOrderCommandResponse() : base()
        {

        }
    }
}