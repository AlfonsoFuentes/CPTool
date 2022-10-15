namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{
    internal class AddBrandHandler : AddBaseHandler<AddBrand, Brand>, IRequestHandler<AddBrand, Result<int>>
    {
      
        public AddBrandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddBrand> logger)
           :base(unitofwork,mapper,emailService,logger) 
        {
          
        }

        
    }
}
