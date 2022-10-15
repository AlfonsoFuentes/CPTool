namespace CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit
{
    internal class AddTaxCodeLDHandler : AddBaseHandler<AddTaxCodeLD, TaxCodeLD>, IRequestHandler<AddTaxCodeLD, Result<int>>
    {


        public AddTaxCodeLDHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddTaxCodeLD> logger)
            : base(unitofwork, mapper, emailService, logger)
        {
            {

            }

        }
    }

}
