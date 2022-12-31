using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Commands.Delete
{
    public class DeleteAlterationItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
