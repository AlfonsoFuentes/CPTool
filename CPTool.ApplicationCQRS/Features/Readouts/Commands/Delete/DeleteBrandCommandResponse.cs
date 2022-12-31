using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Commands.Delete
{
    public class DeleteReadoutCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
