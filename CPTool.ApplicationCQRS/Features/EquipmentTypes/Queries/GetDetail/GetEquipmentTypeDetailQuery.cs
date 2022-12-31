using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetDetail
{
    public class GetEquipmentTypeDetailQuery : IRequest<CommandEquipmentType>
    {
        public int Id { get; set; }
    }
}
