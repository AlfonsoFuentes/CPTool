namespace CPTool.Domain.Entities
{
    public class UserRequirementType : AuditableEntity
    {
        [ForeignKey("UserRequirementTypeId")]
        public ICollection<UserRequirement> UserRequirements { get; set; } = null!;
        public string Key { get; set; } = null!;
    }


}
