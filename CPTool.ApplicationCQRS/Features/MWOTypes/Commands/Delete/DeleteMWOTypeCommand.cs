using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Commands.Delete
{
    public class DeleteMWOTypeCommand : IRequest<DeleteMWOTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
