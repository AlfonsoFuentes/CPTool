using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Commands.Delete
{
    public class DeleteEquipmentTypeCommand : IRequest<DeleteEquipmentTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
