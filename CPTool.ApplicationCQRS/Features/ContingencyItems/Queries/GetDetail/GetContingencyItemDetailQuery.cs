using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Queries.GetDetail
{
    public class GetContingencyItemDetailQuery : IRequest<CommandContingencyItem>
    {
        public int Id { get; set; }
    }
}
