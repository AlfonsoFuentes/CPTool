namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{
    internal class EditBrandHandler : EditBaseHandler<EditBrand, Brand>, IRequestHandler<EditBrand, Result<int>>
    {

        public EditBrandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditBrand> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
