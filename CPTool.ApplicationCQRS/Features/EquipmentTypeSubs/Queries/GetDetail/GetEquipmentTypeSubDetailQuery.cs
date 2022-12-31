using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetDetail
{
    public class GetEquipmentTypeSubDetailQuery : IRequest<CommandEquipmentTypeSub>
    {
        public int Id { get; set; }
    }
}
