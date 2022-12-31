using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Commands.Delete
{
    public class DeleteProcessFluidCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
