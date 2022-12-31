using MediatR;

namespace CPTool.ApplicationCQRSFeatures.StructuralItems.Commands.Delete
{
    public class DeleteStructuralItemCommand : IRequest<DeleteStructuralItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
