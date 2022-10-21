namespace CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit
{
    internal class TaxCodeLPHandler : AddEditBaseHandler<AddTaxCodeLP,EditTaxCodeLP, TaxCodeLP>, IRequestHandler<EditTaxCodeLP, Result<int>>
    {

        public TaxCodeLPHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditTaxCodeLP> logger)
            : base(unitofwork, mapper,  logger)
        {
            {

            }


        }

    }
}
