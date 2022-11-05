using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Query.GetById
{

    public class GetByIdTaxCodeLDQuery : GetByIdQuery, IRequest<EditTaxCodeLD>
    {
        public GetByIdTaxCodeLDQuery() { }
        
    }
    public class GetByIdTaxCodeLDQueryHandler :
        GetByIdQueryHandler<EditTaxCodeLD, TaxCodeLD, GetByIdTaxCodeLDQuery>, 
        IRequestHandler<GetByIdTaxCodeLDQuery, EditTaxCodeLD>
    {

      
        public GetByIdTaxCodeLDQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
