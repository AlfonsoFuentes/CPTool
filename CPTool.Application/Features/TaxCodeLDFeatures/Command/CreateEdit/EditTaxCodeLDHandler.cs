namespace CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit
{
    internal class EditTaxCodeLDHandler : EditBaseHandler<EditTaxCodeLD, TaxCodeLD>, IRequestHandler<EditTaxCodeLD, Result<int>>
    {


        public EditTaxCodeLDHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditTaxCodeLD> logger)
            : base(unitofwork, mapper, emailService, logger)
        {
            {

            }

        }
    }

}
