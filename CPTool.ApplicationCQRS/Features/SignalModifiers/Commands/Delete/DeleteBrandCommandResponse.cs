using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Commands.Delete
{
    public class DeleteSignalModifierCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
