using MediatR;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Commands.Delete
{
    public class DeleteAlterationItemCommand : IRequest<DeleteAlterationItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
