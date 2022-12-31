using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Commands.Delete
{
    public class DeleteFieldLocationCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
