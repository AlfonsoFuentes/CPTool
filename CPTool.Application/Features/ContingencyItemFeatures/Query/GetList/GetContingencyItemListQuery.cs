
using CPTool.Application.Features.ContingencyItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Query.GetList
{

    //public class GetContingencyItemListQuery : GetListQuery, IRequest<List<AddEditContingencyItem>>
    //{



    //}
    //public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetContingencyItemListQuery, List<AddEditContingencyItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditContingencyItem>> Handle(GetContingencyItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<ContingencyItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditContingencyItem>>(list);

    //    }
    //}
}
