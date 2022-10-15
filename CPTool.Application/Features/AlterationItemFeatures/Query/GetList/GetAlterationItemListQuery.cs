
using CPTool.Application.Features.AlterationItemFeatures.CreateEdit;


namespace CPTool.Application.Features.AlterationItemFeatures.Query.GetList
{

    //public class GetAlterationItemListQuery : GetListQuery, IRequest<List<EditAlterationItem>>
    //{



    //}
    //public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetAlterationItemListQuery, List<EditAlterationItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<EditAlterationItem>> Handle(GetAlterationItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<AlterationItem>().GetAllAsync();

    //        return _mapper.Map<List<EditAlterationItem>>(list);

    //    }
    //}
}
