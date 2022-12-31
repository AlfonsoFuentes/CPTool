using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Commands.Delete
{
    public class DeleteEquipmentItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
