using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetList
{
    public class GetEquipmentItemsListQuery : IRequest<List<CommandEquipmentItem>>
    {

    }
}
