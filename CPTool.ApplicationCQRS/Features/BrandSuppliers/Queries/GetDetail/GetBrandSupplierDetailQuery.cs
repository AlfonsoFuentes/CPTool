using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetDetail
{
    public class GetBrandSupplierDetailQuery : IRequest<CommandBrandSupplier>
    {
        public int Id { get; set; }
    }
}
