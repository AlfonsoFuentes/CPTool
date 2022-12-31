using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Commands.Delete
{
    public class DeleteFoundationItemCommand : IRequest<DeleteFoundationItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
