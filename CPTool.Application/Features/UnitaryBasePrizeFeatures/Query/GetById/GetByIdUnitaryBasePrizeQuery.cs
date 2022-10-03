using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetById
{
    
    public class GetByIdUnitaryBasePrizeQuery : GetByIdQuery, IRequest<AddEditUnitaryBasePrizeCommand>
    {
    }
    public class GetByIdUnitaryBasePrizeQueryHandler : IRequestHandler<GetByIdUnitaryBasePrizeQuery, AddEditUnitaryBasePrizeCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdUnitaryBasePrizeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditUnitaryBasePrizeCommand> Handle(GetByIdUnitaryBasePrizeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<UnitaryBasePrize>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditUnitaryBasePrizeCommand>(table);

        }
    }
    
}
