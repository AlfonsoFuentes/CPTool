using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList
{
    public class GetSuppliersListQuery : IRequest<List<CommandSupplier>>
    {
        public int BrandId { get; set; }
    }
}
