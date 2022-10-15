namespace CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit
{
    internal class EditTaxCodeLPHandler : EditBaseHandler<EditTaxCodeLP, TaxCodeLP>, IRequestHandler<EditTaxCodeLP, Result<int>>
    {

        public EditTaxCodeLPHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditTaxCodeLP> logger)
            : base(unitofwork, mapper, emailService, logger)
        {
            {

            }


        }

    }
}
