
using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetList
{

    public class GetEquipmentItemListQuery : GetListQuery, IRequest<List<AddEditEquipmentItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetEquipmentItemListQuery, List<AddEditEquipmentItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditEquipmentItemCommand>> Handle(GetEquipmentItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EquipmentItem>().GetAllAsync();

            return _mapper.Map<List<AddEditEquipmentItemCommand>>(list);

        }
    }
}
