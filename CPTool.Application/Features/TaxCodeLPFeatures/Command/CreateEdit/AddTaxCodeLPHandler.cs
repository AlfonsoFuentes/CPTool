namespace CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit
{
    internal class AddTaxCodeLPHandler : AddBaseHandler<AddTaxCodeLP, TaxCodeLP>, IRequestHandler<AddTaxCodeLP, Result<int>>
    {

        public AddTaxCodeLPHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddTaxCodeLP> logger)
            : base(unitofwork, mapper, emailService, logger)
        {
            {

            }


        }
    }
}