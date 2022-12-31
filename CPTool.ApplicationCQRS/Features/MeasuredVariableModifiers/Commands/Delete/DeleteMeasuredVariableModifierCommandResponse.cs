using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Commands.Delete
{
    public class DeleteMeasuredVariableModifierCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
