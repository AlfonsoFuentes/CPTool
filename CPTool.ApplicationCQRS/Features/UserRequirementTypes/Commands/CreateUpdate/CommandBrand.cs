using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate
{
    public class CommandUserRequirementType : CommandBase, IRequest<UserRequirementTypeCommandResponse>
    {


        public string Key { get; set; } = string.Empty;

    }

}
