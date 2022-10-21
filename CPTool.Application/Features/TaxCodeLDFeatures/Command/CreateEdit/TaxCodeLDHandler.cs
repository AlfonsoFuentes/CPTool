namespace CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit
{
    internal class TaxCodeLDHandler : AddEditBaseHandler<AddTaxCodeLD,EditTaxCodeLD, TaxCodeLD>, IRequestHandler<EditTaxCodeLD, Result<int>>
    {


        public TaxCodeLDHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditTaxCodeLD> logger)
            : base(unitofwork, mapper,  logger)
        {
            {

            }

        }
    }

}
