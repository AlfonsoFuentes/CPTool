using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetById
{

    public class GetByIdUnitaryBasePrizeQuery : GetByIdQuery, IRequest<EditUnitaryBasePrize>
    {
        public GetByIdUnitaryBasePrizeQuery() { }
        
    }
    public class GetByIdUnitaryBasePrizeQueryHandler : IRequestHandler<GetByIdUnitaryBasePrizeQuery, EditUnitaryBasePrize>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdUnitaryBasePrizeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditUnitaryBasePrize> Handle(GetByIdUnitaryBasePrizeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<UnitaryBasePrize>().GetByIdAsync(request.Id);

            return _mapper.Map<EditUnitaryBasePrize>(table);

        }
    }
    
}
