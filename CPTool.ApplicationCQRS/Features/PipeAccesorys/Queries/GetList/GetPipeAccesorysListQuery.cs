using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeAccesorys.Queries.GetList
{
    public class GetPipeAccesorysListQuery : IRequest<List<CommandPipeAccesory>>
    {

    }
}
