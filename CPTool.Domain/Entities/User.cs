namespace CPTool.Domain.Entities
{
    public class User:AuditableEntity
    {
        
        public string Email { get; set; } = "";
        
        public string MobilPhone { get; set; } = "";
        public string Password { get; set; } = "";

        [ForeignKey("UserId")]
        public ICollection<MWO> MWOs { get; set; } = null!;
        [ForeignKey("RequestedById")]
        public ICollection<UserRequirement> UserRequirements { get; set; } = null!;

    }


}
