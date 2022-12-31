using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Commands.Delete
{
    public class DeleteDownPaymentCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
