


using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementFeatures.CreateEdit
{
    public class EditUserRequirement : EditCommand, IRequest<Result<int>>
    {
       
        public int? UserRequirementTypeId => UserRequirementType==null?null:UserRequirementType.Id;
        public EditUserRequirementType? UserRequirementType { get; set; } = null!;
        [Report]
        public string UserRequirementTypeName => UserRequirementType==null?"": UserRequirementType!.Name;
        public int? MWOId =>MWO==null?null: MWO.Id;
        public EditMWO? MWO { get; set; } = null!;
        [Report]
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public int? RequestedById => RequestedBy!.Id == 0 ? null : RequestedBy!.Id;
        public int? RequestedByUserId => 0;
        public EditUser? RequestedBy { get; set; } = new();
        [Report]
        public string RequestedByName => RequestedBy == null ? "" : RequestedBy!.Name;
    }

}
