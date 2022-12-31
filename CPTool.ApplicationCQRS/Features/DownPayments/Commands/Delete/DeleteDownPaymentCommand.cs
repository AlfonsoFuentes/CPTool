using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Commands.Delete
{
    public class DeleteDownPaymentCommand : IRequest<DeleteDownPaymentCommandResponse>
    {
        public int Id { get; set; }
    }
}
