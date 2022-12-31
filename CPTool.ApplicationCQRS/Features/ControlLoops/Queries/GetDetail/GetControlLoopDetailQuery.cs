using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetDetail
{
    public class GetControlLoopDetailQuery : IRequest<CommandControlLoop>
    {
        public int Id { get; set; }
    }
}
