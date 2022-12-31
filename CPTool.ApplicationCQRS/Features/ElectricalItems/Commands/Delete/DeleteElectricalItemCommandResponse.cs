using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Commands.Delete
{
    public class DeleteElectricalItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
