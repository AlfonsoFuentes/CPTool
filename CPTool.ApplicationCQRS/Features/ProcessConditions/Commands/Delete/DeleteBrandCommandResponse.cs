using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Commands.Delete
{
    public class DeleteProcessConditionCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
