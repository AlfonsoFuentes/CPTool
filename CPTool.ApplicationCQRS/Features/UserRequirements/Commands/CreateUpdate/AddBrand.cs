namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class AddUserRequirement
    {

       
        public string Name { get; set; } = string.Empty;
        public int? UserRequirementTypeId { get; set; }

        public int? MWOId { get; set; }
        public int? RequestedById { get; set; }
        public int? RequestedByUserId { get; set; }
    }

}
