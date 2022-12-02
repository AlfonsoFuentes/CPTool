namespace CPTool.Application.Features.UserFeatures.CreateEdit
{
    public class EditUser : EditCommand, IRequest<Result<int>>
    {
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string MobilPhone { get; set; } = "";
    }
}