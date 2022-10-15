
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList
{

    public class GetTaxCodeLPListQuery : GetListQuery, IRequest<List<EditTaxCodeLP>>
    {



    }
    public class GetTaxCodeLPListQueryHandler : IRequestHandler<GetTaxCodeLPListQuery, List<EditTaxCodeLP>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTaxCodeLPListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditTaxCodeLP>> Handle(GetTaxCodeLPListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TaxCodeLP>().GetAllAsync();

            return _mapper.Map<List<EditTaxCodeLP>>(list);

        }
    }
}
