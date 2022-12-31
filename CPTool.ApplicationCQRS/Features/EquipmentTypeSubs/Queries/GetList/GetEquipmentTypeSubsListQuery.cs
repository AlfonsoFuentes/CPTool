using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetList
{
    public class GetEquipmentTypeSubsListQuery : IRequest<List<CommandEquipmentTypeSub>>
    {
        public int EquipmentTypeId { get; set; }
    }
}
