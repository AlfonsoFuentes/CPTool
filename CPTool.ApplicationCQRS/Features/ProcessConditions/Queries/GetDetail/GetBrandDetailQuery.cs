using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Queries.GetDetail
{
    public class GetProcessConditionDetailQuery : IRequest<CommandProcessCondition>
    {
        public int Id { get; set; }
    }
}
