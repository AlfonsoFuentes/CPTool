using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList
{
    public class GetPipeDiametersListQuery : IRequest<List<CommandPipeDiameter>>
    {
        public int PipeClassId { get; set; }
    }
}
