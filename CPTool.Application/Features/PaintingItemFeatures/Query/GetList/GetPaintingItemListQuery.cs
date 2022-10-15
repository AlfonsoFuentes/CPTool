
using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Query.GetList
{

    public class GetPaintingItemListQuery : GetListQuery, IRequest<List<EditPaintingItem>>
    {



    }
    public class GetPaintingItemListQueryHandler : IRequestHandler<GetPaintingItemListQuery, List<EditPaintingItem>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPaintingItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPaintingItem>> Handle(GetPaintingItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PaintingItem>().GetAllAsync();

            return _mapper.Map<List<EditPaintingItem>>(list);

        }
    }
}
