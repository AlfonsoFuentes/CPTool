
using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Query.GetList
{

    //public class GetStructuralItemListQuery : GetListQuery, IRequest<List<AddEditStructuralItem>>
    //{



    //}
    //public class GetStructuralItemListQueryHandler : IRequestHandler<GetStructuralItemListQuery, List<AddEditStructuralItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetStructuralItemListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditStructuralItem>> Handle(GetStructuralItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<StructuralItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditStructuralItem>>(list);

    //    }
    //}
}
