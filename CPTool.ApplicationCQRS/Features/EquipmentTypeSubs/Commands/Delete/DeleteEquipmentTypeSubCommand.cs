using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Commands.Delete
{
    public class DeleteEquipmentTypeSubCommand : IRequest<DeleteEquipmentTypeSubCommandResponse>
    {
        public int Id { get; set; }
    }
}
