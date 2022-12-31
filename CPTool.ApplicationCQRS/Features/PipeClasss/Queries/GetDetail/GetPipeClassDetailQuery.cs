using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetDetail
{
    public class GetPipeClassDetailQuery : IRequest<CommandPipeClass>
    {
        public int Id { get; set; }
    }
}
