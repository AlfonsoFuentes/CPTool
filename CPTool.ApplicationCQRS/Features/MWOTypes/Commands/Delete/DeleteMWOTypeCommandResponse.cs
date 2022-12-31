using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Commands.Delete
{
    public class DeleteMWOTypeCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
