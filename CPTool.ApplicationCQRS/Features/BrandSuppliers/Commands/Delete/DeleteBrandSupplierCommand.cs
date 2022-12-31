using MediatR;

namespace CPTool.ApplicationCQRSFeatures.BrandSuppliers.Commands.Delete
{
    public class DeleteBrandSupplierCommand : IRequest<DeleteBrandSupplierCommandResponse>
    {
        public int Id { get; set; }
    }
}
