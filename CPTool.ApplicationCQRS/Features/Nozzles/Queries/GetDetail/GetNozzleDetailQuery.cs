using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetDetail
{
    public class GetNozzleDetailQuery : IRequest<CommandNozzle>
    {
        public int Id { get; set; }
    }
}
