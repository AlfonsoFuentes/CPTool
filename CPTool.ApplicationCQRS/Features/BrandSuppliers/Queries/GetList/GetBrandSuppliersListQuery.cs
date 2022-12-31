using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetList
{
    public class GetBrandSuppliersListQuery : IRequest<List<CommandBrandSupplier>>
    {

    }
}
