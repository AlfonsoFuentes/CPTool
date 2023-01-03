using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetList
{
    public class GetControlLoopsListQuery : IRequest<List<CommandControlLoop>>
    {
        public int MWOId { get; set; }
    }
}
