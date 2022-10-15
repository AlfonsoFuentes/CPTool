
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList
{

    public class GetUnitaryBasePrizeListQuery : GetListQuery, IRequest<List<EditUnitaryBasePrize>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetUnitaryBasePrizeListQuery, List<EditUnitaryBasePrize>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditUnitaryBasePrize>> Handle(GetUnitaryBasePrizeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<UnitaryBasePrize>().GetAllAsync();

            return _mapper.Map<List<EditUnitaryBasePrize>>(list);

        }
    }
}
