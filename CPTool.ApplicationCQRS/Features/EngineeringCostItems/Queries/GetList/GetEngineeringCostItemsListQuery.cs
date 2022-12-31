using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetList
{
    public class GetEngineeringCostItemsListQuery : IRequest<List<CommandEngineeringCostItem>>
    {

    }
}
