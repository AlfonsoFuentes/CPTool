using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Queries.GetList
{
    public class GetProcessConditionsListQuery : IRequest<List<CommandProcessCondition>>
    {

    }
}
