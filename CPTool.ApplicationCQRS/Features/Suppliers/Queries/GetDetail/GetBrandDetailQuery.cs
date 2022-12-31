using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetDetail
{
    public class GetSupplierDetailQuery : IRequest<CommandSupplier>
    {
        public int Id { get; set; }
    }
}
