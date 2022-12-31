using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Commands.Delete
{
    public class DeleteEHSItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
