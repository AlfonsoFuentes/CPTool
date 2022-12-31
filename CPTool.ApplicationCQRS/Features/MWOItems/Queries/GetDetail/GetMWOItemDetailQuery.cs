using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetDetail
{
    public class GetMWOItemDetailQuery : IRequest<CommandMWOItem>
    {
        public int Id { get; set; }
    }
}
