using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Commands.Delete
{
    public class DeleteEngineeringCostItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
