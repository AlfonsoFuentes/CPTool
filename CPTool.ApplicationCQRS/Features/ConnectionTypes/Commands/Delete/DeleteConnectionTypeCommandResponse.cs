using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Commands.Delete
{
    public class DeleteConnectionTypeCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
