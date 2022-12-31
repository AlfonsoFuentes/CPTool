using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Materials.Commands.Delete
{
    public class DeleteMaterialCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
