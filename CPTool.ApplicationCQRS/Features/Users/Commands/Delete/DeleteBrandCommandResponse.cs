using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Users.Commands.Delete
{
    public class DeleteUserCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
