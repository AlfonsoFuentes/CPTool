using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Queries.GetDetail
{
    public class GetAlterationItemDetailQuery : IRequest<CommandAlterationItem>
    {
        public int Id { get; set; }
    }
}
