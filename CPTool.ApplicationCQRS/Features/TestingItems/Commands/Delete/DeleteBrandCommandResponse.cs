using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Commands.Delete
{
    public class DeleteTestingItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
