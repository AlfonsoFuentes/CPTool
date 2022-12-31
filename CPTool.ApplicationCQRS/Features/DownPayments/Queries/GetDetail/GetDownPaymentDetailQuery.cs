using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetDetail
{
    public class GetDownPaymentDetailQuery : IRequest<CommandDownPayment>
    {
        public int Id { get; set; }
    }
}
