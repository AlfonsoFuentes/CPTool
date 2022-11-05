
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList
{

    public class GetTaxCodeLPListQuery : GetListQuery, IRequest<List<EditTaxCodeLP>>
    {



    }
    public class GetTaxCodeLPListQueryHandler :
         GetListQueryHandler<EditTaxCodeLP, TaxCodeLP, GetTaxCodeLPListQuery>,
        IRequestHandler<GetTaxCodeLPListQuery, List<EditTaxCodeLP>>
    {
        public GetTaxCodeLPListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
