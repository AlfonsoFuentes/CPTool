using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetDetail
{
    public class GetUserRequirementTypeDetailQuery : IRequest<CommandUserRequirementType>
    {
        public int Id { get; set; }
    }
}
