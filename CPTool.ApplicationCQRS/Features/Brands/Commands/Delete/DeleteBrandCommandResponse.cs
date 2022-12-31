using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Brands.Commands.Delete
{
    public class DeleteBrandCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
