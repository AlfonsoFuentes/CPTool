using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Signals.Commands.Delete
{
    public class DeleteSignalCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
