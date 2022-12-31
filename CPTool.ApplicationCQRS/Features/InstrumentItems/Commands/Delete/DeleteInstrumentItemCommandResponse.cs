using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Commands.Delete
{
    public class DeleteInstrumentItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
