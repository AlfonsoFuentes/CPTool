namespace CPTool.Application.Features.UserFeatures.CreateEdit
{
    public class EditUser : EditCommand, IRequest<Result<int>>
    {
        [Report]
        public string Password { get; set; } = "";
        [Report] public string Email { get; set; } = "";
        [Report] public string MobilPhone { get; set; } = "";
    }
}