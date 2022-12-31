using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeAccesorys.Queries.GetDetail
{
    public class GetPipeAccesoryDetailQuery : IRequest<CommandPipeAccesory>
    {
        public int Id { get; set; }
    }
}
