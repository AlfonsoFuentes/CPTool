
using CPTool.Application.Features.FoundationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Query.GetList
{

    //public class GetFoundationItemListQuery : GetListQuery, IRequest<List<AddFoundationItem>>
    //{



    //}
    //public class GetFoundationItemListQueryHandler : IRequestHandler<GetFoundationItemListQuery, List<AddFoundationItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetFoundationItemListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddFoundationItem>> Handle(GetFoundationItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<FoundationItem>().GetAllAsync();

    //        return _mapper.Map<List<AddFoundationItem>>(list);

    //    }
    //}
}
