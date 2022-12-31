using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetList
{
    public class GetUserRequirementTypesListQuery : IRequest<List<CommandUserRequirementType>>
    {

    }
}
