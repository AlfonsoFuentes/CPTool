
using CPTool.Application.Features.InsulationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Query.GetList
{

    //public class GetInsulationItemListQuery : GetListQuery, IRequest<List<AddEditInsulationItem>>
    //{



    //}
    //public class GetInsulationItemListQueryHandler : IRequestHandler<GetInsulationItemListQuery, List<AddEditInsulationItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetInsulationItemListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditInsulationItem>> Handle(GetInsulationItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<InsulationItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditInsulationItem>>(list);

    //    }
    //}
}
