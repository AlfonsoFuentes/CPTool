
using CPTool.Application.Features.TestingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Query.GetList
{

    //public class GetTestingItemListQuery : GetListQuery, IRequest<List<AddEditTestingItem>>
    //{



    //}
    //public class GetTestingItemListQueryHandler : IRequestHandler<GetTestingItemListQuery, List<AddEditTestingItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetTestingItemListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditTestingItem>> Handle(GetTestingItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<TestingItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditTestingItem>>(list);

    //    }
    //}
}
