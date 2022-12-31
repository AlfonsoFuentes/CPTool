using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Commands.Delete
{
    public class DeleteContingencyItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
