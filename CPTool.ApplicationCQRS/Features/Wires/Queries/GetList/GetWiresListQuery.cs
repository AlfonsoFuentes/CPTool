using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Wires.Queries.GetList
{
    public class GetWiresListQuery : IRequest<List<CommandWire>>
    {

    }
}
