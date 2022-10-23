using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetById
{

    public class GetByIdInstrumentItemQuery : GetByIdQuery, IRequest<EditInstrumentItem>
    {
        
    }
    public class GetByIdInstrumentItemQueryHandler : IRequestHandler<GetByIdInstrumentItemQuery, EditInstrumentItem>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdInstrumentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditInstrumentItem> Handle(GetByIdInstrumentItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.RepositoryInstrumentItem.GetByIdAsync(request.Id);

            return _mapper.Map<EditInstrumentItem>(table);

        }
    }
    
}
