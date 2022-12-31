using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetDetail
{
    public class GetReadoutDetailQuery : IRequest<CommandReadout>
    {
        public int Id { get; set; }
    }
}
