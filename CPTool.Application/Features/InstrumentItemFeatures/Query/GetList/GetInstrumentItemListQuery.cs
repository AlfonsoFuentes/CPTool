
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetList
{

    public class GetInstrumentItemListQuery : GetListQuery, IRequest<List<AddEditInstrumentItemCommand>>
    {



    }
    public class GetInstrumentItemListQueryHandler : IRequestHandler<GetInstrumentItemListQuery, List<AddEditInstrumentItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetInstrumentItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditInstrumentItemCommand>> Handle(GetInstrumentItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<InstrumentItem>().GetAllAsync();

            return _mapper.Map<List<AddEditInstrumentItemCommand>>(list);

        }
    }
}
