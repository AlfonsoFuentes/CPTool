using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Commands.Delete
{
    public class DeleteMWOCommand : IRequest<DeleteMWOCommandResponse>
    {
        public int Id { get; set; }
    }
}
