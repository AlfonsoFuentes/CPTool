using CPTool.ApplicationCQRSResponses;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Commands.Delete
{
    public class DeleteSupplierCommandResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}
