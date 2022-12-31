using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Commands.Delete
{
    public class DeleteMeasuredVariableCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
