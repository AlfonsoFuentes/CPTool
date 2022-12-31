using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetList
{
    public class GetUserRequirementsListQuery : IRequest<List<CommandUserRequirement>>
    {

    }
}
