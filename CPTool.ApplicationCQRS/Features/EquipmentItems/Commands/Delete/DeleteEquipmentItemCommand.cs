using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Commands.Delete
{
    public class DeleteEquipmentItemCommand : IRequest<DeleteEquipmentItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
