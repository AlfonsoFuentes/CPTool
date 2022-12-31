using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Commands.Delete
{
    public class DeleteMWOCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
