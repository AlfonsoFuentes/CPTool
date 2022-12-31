using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Wires.Queries.GetDetail
{
    public class GetWireDetailQuery : IRequest<CommandWire>
    {
        public int Id { get; set; }
    }
}
