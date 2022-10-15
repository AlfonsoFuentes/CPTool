namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    internal class EditSupplierHandler : EditBaseHandler<EditSupplier, Supplier>, IRequestHandler<EditSupplier, Result<int>>
    {

        public EditSupplierHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditSupplier> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
