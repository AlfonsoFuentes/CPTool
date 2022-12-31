using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetDetail
{
    public class GetMWODetailQuery : IRequest<CommandMWO>
    {
        public int Id { get; set; }
    }
}
