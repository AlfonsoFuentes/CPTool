
using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList
{

    public class GetTaxCodeLPListQuery : GetListQuery, IRequest<List<AddEditTaxCodeLPCommand>>
    {



    }
    public class GetTaxCodeLPListQueryHandler : IRequestHandler<GetTaxCodeLPListQuery, List<AddEditTaxCodeLPCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTaxCodeLPListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditTaxCodeLPCommand>> Handle(GetTaxCodeLPListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TaxCodeLP>().GetAllAsync();

            return _mapper.Map<List<AddEditTaxCodeLPCommand>>(list);

        }
    }
}
