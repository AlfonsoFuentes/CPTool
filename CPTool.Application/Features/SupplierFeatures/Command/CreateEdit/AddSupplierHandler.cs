namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    internal class AddSupplierHandler :AddBaseHandler<AddSupplier,Supplier>, IRequestHandler<AddSupplier, Result<int>>
    {
      
        public AddSupplierHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddSupplier> logger)
            :base(unitofwork,mapper,emailService,logger)
        {
          
        }

        
    }
}
