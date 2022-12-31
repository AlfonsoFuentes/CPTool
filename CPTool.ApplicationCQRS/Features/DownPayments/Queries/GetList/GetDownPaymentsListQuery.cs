using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetList
{
    public class GetDownPaymentsListQuery : IRequest<List<CommandDownPayment>>
    {

    }
}
