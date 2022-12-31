using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Commands.Delete
{
    public class DeleteFoundationItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
