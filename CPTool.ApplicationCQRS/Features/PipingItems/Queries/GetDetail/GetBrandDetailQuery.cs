using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Queries.GetDetail
{
    public class GetPipingItemDetailQuery : IRequest<CommandPipingItem>
    {
        public int Id { get; set; }
    }
}
