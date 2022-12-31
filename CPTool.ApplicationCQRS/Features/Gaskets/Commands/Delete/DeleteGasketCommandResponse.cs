using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Commands.Delete
{
    public class DeleteGasketCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
