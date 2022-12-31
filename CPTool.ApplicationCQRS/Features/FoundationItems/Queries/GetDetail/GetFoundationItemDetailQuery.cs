using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Queries.GetDetail
{
    public class GetFoundationItemDetailQuery : IRequest<CommandFoundationItem>
    {
        public int Id { get; set; }
    }
}
