using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Commands.Delete
{
    public class DeleteTestingItemCommand : IRequest<DeleteTestingItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
