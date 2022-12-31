using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Commands.Delete
{
    public class DeletePipingItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
