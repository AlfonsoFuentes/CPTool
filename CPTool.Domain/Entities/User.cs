namespace CPTool.Domain.Entities
{
    public class User:BaseDomainModel
    {
        
        public string Email { get; set; } = "";
        
        public string MobilPhone { get; set; } = "";
        public string Password { get; set; } = "";

       
        public ICollection<UserRequirement> UserRequirements { get; set; } = null!;

    }


}
