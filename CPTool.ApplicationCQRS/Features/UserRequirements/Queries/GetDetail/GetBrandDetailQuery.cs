using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetDetail
{
    public class GetUserRequirementDetailQuery : IRequest<CommandUserRequirement>
    {
        public int Id { get; set; }
    }
}
