namespace CPTool.Domain.Entities
{
    public class UserRequirement : AuditableEntity
    {
        public int? UserRequirementTypeId { get; set; }
        public UserRequirementType? UserRequirementType { get; set; } = null!;
      
        public int? MWOId { get; set; }
        public MWO? MWO { get; set; } = null!;

        public int? RequestedByUserId { get; set; }
        //public User? RequestedByUser { get; set; } = null!;
       
        public int? RequestedById { get; set; }
        public User? RequestedBy { get; set; } = null!;

    }


}
