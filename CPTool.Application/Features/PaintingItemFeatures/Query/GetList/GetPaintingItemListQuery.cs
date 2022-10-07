
using CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Query.GetList
{

    public class GetPaintingItemListQuery : GetListQuery, IRequest<List<AddEditPaintingItemCommand>>
    {



    }
    public class GetPaintingItemListQueryHandler : IRequestHandler<GetPaintingItemListQuery, List<AddEditPaintingItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPaintingItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPaintingItemCommand>> Handle(GetPaintingItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PaintingItem>().GetAllAsync();

            return _mapper.Map<List<AddEditPaintingItemCommand>>(list);

        }
    }
}
