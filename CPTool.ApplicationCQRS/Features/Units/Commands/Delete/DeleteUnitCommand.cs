using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Units.Commands.Delete
{
    public class DeleteUnitCommand : IRequest<DeleteUnitCommandResponse>
    {
        public int Id { get; set; }
    }
}
