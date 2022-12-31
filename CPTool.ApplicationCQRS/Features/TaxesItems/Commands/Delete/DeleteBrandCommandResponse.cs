using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Commands.Delete
{
    public class DeleteTaxesItemCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
