using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetDetail
{
    public class GetMeasuredVariableModifierDetailQuery : IRequest<CommandMeasuredVariableModifier>
    {
        public int Id { get; set; }
    }
}
