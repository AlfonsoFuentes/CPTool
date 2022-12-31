using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Takss.Queries.GetDetail
{
    public class GetTaksDetailQuery : IRequest<CommandTaks>
    {
        public int Id { get; set; }
    }
}
