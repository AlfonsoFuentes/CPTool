
using CPTool.Application.Features.EngineeringCostItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Query.GetList
{

    public class GetEngineeringCostItemListQuery : GetListQuery, IRequest<List<AddEditEngineeringCostItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetEngineeringCostItemListQuery, List<AddEditEngineeringCostItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditEngineeringCostItemCommand>> Handle(GetEngineeringCostItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EngineeringCostItem>().GetAllAsync();

            return _mapper.Map<List<AddEditEngineeringCostItemCommand>>(list);

        }
    }
}
