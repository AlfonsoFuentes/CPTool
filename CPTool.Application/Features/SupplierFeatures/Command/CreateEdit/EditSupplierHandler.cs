namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    internal class SupplierHandler : AddEditBaseHandler<AddSupplier,EditSupplier, Supplier>, IRequestHandler<EditSupplier, Result<int>>
    {

        public SupplierHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditSupplier> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
