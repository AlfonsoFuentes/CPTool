using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetList
{
    public class GetElectricalItemsListQuery : IRequest<List<CommandElectricalItem>>
    {

    }
}
