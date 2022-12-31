using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Takss.Commands.Delete
{
    public class DeleteTaksCommand : IRequest<DeleteTaksCommandResponse>
    {
        public int Id { get; set; }
    }
}
