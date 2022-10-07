using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetById
{
    
    public class GetByIdInstrumentItemQuery : GetByIdQuery, IRequest<AddEditInstrumentItemCommand>
    {
    }
    public class GetByIdInstrumentItemQueryHandler : IRequestHandler<GetByIdInstrumentItemQuery, AddEditInstrumentItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdInstrumentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditInstrumentItemCommand> Handle(GetByIdInstrumentItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<InstrumentItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditInstrumentItemCommand>(table);

        }
    }
    
}
