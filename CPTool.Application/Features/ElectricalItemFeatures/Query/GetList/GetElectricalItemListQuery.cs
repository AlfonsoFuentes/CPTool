
using CPTool.Application.Features.ElectricalItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Query.GetList
{

    //public class GetElectricalItemListQuery : GetListQuery, IRequest<List<AddEditElectricalItem>>
    //{



    //}
    //public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetElectricalItemListQuery, List<AddEditElectricalItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditElectricalItem>> Handle(GetElectricalItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<ElectricalItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditElectricalItem>>(list);

    //    }
    //}
}
