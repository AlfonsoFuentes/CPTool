using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Wires.Commands.Delete
{
    public class DeleteWireCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
