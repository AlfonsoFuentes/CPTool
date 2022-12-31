using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Commands.Delete
{
    public class DeleteContingencyItemCommand : IRequest<DeleteContingencyItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
