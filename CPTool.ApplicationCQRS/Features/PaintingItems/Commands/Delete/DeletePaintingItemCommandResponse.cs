using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Commands.Delete
{
    public class DeletePaintingItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
