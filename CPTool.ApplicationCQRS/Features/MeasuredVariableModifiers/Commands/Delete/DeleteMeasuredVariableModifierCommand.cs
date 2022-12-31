using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Commands.Delete
{
    public class DeleteMeasuredVariableModifierCommand : IRequest<DeleteMeasuredVariableModifierCommandResponse>
    {
        public int Id { get; set; }
    }
}
