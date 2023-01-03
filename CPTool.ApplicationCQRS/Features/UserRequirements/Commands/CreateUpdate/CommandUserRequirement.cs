using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class CommandUserRequirement : CommandBase, IRequest<UserRequirementCommandResponse>
    {


        public int? UserRequirementTypeId => UserRequirementType == null ? null : UserRequirementType.Id;
        public CommandUserRequirementType? UserRequirementType { get; set; } = new();
        public string UserRequirementTypeName => UserRequirementType == null ? "" : UserRequirementType!.Name;
        public int? MWOId => MWO == null ? null : MWO.Id;
        public CommandMWO? MWO { get; set; } = new();
        
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public int? RequestedById => RequestedBy!.Id == 0 ? null : RequestedBy!.Id;
        public int? RequestedByUserId => 0;
        public CommandUser? RequestedBy { get; set; } = new();
        
        public string RequestedByName => RequestedBy == null ? "" : RequestedBy!.Name;

    }

}
