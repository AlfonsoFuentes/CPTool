using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate
{
    public class DownPaymentCommandResponse : BaseResponse
    {
        public DownPaymentCommandResponse() : base()
        {

        }

        public CommandDownPayment? DownPaymentObject { get; set; }
    }
}