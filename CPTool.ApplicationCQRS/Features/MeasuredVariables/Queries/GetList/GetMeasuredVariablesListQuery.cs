using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetList
{
    public class GetMeasuredVariablesListQuery : IRequest<List<CommandMeasuredVariable>>
    {

    }
}
