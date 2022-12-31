using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Commands.Delete
{
    public class DeleteMeasuredVariableCommand : IRequest<DeleteMeasuredVariableCommandResponse>
    {
        public int Id { get; set; }
    }
}
