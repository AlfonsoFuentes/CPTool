namespace CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate
{
    public class AddUser
    {

       
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobilPhone { get; set; } = string.Empty;
    }

}
