using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList
{
    public class GetPipeClasssListQuery : IRequest<List<CommandPipeClass>>
    {

    }
}
