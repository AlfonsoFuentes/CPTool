
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetList
{

    //public class GetEquipmentItemListQuery : GetListQuery, IRequest<List<AddEditEquipmentItem>>
    //{



    //}
    //public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetEquipmentItemListQuery, List<AddEditEquipmentItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditEquipmentItem>> Handle(GetEquipmentItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<EquipmentItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditEquipmentItem>>(list);

    //    }
    //}
}
