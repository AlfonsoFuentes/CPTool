using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetDetail
{
    public class GetMeasuredVariableDetailQuery : IRequest<CommandMeasuredVariable>
    {
        public int Id { get; set; }
    }
}
