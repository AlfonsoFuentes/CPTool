using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Commands.Delete
{
    public class DeleteEHSItemCommand : IRequest<DeleteEHSItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
