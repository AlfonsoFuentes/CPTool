using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Commands.Delete
{
    public class DeleteMWOItemCommand : IRequest<DeleteMWOItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
