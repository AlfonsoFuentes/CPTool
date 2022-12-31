using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InsulationItems.Commands.Delete
{
    public class DeleteInsulationItemCommand : IRequest<DeleteInsulationItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
