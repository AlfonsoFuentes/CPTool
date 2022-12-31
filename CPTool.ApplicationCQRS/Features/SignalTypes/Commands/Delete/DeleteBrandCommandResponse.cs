using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Commands.Delete
{
    public class DeleteSignalTypeCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
