using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Commands.Delete
{
    public class DeleteControlLoopCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
