using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate
{
    public class DownPaymentCommandResponse : BaseResponse<CommandDownPayment>
    {
        public DownPaymentCommandResponse() : base()
        {

        }
    }
}