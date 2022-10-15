
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetList
{

    public class GetInstrumentItemListQuery : GetListQuery, IRequest<List<EditInstrumentItem>>
    {



    }
    public class GetInstrumentItemListQueryHandler : IRequestHandler<GetInstrumentItemListQuery, List<EditInstrumentItem>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetInstrumentItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditInstrumentItem>> Handle(GetInstrumentItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<InstrumentItem>().GetAllAsync();

            return _mapper.Map<List<EditInstrumentItem>>(list);

        }
    }
}
