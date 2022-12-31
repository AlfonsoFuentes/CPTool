using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetList
{
    public class GetEquipmentTypesListQuery : IRequest<List<CommandEquipmentType>>
    {

    }
}
