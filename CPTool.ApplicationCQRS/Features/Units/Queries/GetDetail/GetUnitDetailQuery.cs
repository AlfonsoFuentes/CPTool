using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Units.Queries.GetDetail
{
    public class GetUnitDetailQuery : IRequest<CommandUnit>
    {
        public int Id { get; set; }
    }
}
