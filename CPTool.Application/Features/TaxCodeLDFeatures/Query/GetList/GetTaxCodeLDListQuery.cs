
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList
{

    public class GetTaxCodeLDListQuery : GetListQuery, IRequest<List<EditTaxCodeLD>>
    {



    }
    public class GetTaxCodeLDListQueryHandler :
          GetListQueryHandler<EditTaxCodeLD, TaxCodeLD, GetTaxCodeLDListQuery>,
        IRequestHandler<GetTaxCodeLDListQuery, List<EditTaxCodeLD>>
    {
        public GetTaxCodeLDListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
