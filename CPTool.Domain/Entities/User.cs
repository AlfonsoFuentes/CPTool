namespace CPTool.Domain.Entities
{
    public class User:BaseDomainModel
    {
        public string Email { get; set; } = null!;
        
        public string MobilPhone { get; set; } = null!;
        public string Password { get; set; } = null!;

        [ForeignKey("RequestedById")]
        public ICollection<UserRequirement> UserRequirements { get; set; } = null!;
    }


}
