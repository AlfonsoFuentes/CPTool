using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InsulationItems.Queries.GetDetail
{
    public class GetInsulationItemDetailQuery : IRequest<CommandInsulationItem>
    {
        public int Id { get; set; }
    }
}
