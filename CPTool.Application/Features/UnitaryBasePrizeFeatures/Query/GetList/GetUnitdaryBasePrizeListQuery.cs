
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList
{

    public class GetUnitaryBasePrizeListQuery : GetListQuery, IRequest<List<AddEditUnitaryBasePrizeCommand>>
    {



    }
    public class GetUnitdaryBasePrizeListQueryHandler : IRequestHandler<GetUnitaryBasePrizeListQuery, List<AddEditUnitaryBasePrizeCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitdaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditUnitaryBasePrizeCommand>> Handle(GetUnitaryBasePrizeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Gasket>().GetAllAsync();

            return _mapper.Map<List<AddEditUnitaryBasePrizeCommand>>(list);

        }
    }
}
