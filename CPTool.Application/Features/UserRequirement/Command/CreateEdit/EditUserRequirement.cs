


using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementFeatures.CreateEdit
{
    public class EditUserRequirement : EditCommand, IRequest<Result<int>>
    {
       
        public int? UserRequirementTypeId => UserRequirementType==null?null:UserRequirementType.Id;
        public EditUserRequirementType? UserRequirementType { get; set; } = null!;

        public int? MWOId =>MWO==null?null: MWO.Id;
        public EditMWO? MWO { get; set; } = null!;

        public int? RequestedById => RequestedBy == null ? null : RequestedBy.Id;
        public EditUser RequestedBy { get; set; } = null!;
    }

}
