using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Commands.Delete
{
    public class DeletePropertySpecificationCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
