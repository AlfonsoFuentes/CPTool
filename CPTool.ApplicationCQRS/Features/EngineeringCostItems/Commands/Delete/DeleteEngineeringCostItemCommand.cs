using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Commands.Delete
{
    public class DeleteEngineeringCostItemCommand : IRequest<DeleteEngineeringCostItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
