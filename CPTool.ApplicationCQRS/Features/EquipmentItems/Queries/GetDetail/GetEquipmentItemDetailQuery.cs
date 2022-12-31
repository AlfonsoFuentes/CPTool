using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetDetail
{
    public class GetEquipmentItemDetailQuery : IRequest<CommandEquipmentItem>
    {
        public int Id { get; set; }
    }
}
