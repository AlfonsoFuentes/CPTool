using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetDetail
{
    public class GetEngineeringCostItemDetailQuery : IRequest<CommandEngineeringCostItem>
    {
        public int Id { get; set; }
    }
}
