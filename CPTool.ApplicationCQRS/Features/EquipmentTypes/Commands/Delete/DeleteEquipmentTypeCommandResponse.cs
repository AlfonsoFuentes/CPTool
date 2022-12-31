using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Commands.Delete
{
    public class DeleteEquipmentTypeCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
