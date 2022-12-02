

namespace CPTool.Application.Features.UserRequirementFeatures.CreateEdit
{
    public class AddUserRequirement : AddCommand
    {
       
        public int? UserRequirementTypeId { get; set; }

        public int? MWOId { get; set; }
        public int? RequestedById { get; set; }
        public int? RequestedByUserId { get; set; }
    }
}
