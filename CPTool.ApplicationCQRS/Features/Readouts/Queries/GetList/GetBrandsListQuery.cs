using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetList
{
    public class GetReadoutsListQuery : IRequest<List<CommandReadout>>
    {

    }
}
