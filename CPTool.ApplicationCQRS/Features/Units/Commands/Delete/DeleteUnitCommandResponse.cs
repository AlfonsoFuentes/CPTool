using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Units.Commands.Delete
{
    public class DeleteUnitCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
