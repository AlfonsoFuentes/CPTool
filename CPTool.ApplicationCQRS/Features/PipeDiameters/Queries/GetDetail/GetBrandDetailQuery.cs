using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetDetail
{
    public class GetPipeDiameterDetailQuery : IRequest<CommandPipeDiameter>
    {
        public int Id { get; set; }
    }
}
