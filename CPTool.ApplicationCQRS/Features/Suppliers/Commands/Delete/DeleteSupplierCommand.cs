using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Commands.Delete
{
    public class DeleteSupplierCommand : IRequest<DeleteSupplierCommandResponse>
    {
        public int Id { get; set; }
    }
}
