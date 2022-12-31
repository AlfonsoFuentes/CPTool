using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetList
{
    public class GetMeasuredVariableModifiersListQuery : IRequest<List<CommandMeasuredVariableModifier>>
    {

    }
}
