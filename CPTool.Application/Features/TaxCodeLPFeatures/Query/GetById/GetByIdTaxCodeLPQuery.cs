using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Query.GetById;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetById
{

    public class GetByIdTaxCodeLPQuery : GetByIdQuery, IRequest<EditTaxCodeLP>
    {
        public GetByIdTaxCodeLPQuery() { }
       
    }
    public class GetByIdTaxCodeLPQueryHandler :
        GetByIdQueryHandler<EditTaxCodeLP, TaxCodeLP, GetByIdTaxCodeLPQuery>, 
        IRequestHandler<GetByIdTaxCodeLPQuery, EditTaxCodeLP>
    {

      
        public GetByIdTaxCodeLPQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
        }
    }


