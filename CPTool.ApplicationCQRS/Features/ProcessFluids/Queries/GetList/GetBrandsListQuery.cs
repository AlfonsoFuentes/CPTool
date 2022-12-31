using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetList
{
    public class GetProcessFluidsListQuery : IRequest<List<CommandProcessFluid>>
    {

    }
}
