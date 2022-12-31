using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Commands.Delete
{
    public class DeleteNozzleCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
