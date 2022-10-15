
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Query.GetList
{

    public class GetPipingItemListQuery : GetListQuery, IRequest<List<EditPipingItem>>
    {



    }
    public class GetPipingItemListQueryHandler : IRequestHandler<GetPipingItemListQuery, List<EditPipingItem>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipingItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPipingItem>> Handle(GetPipingItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipingItem>().GetAllAsync();

            return _mapper.Map<List<EditPipingItem>>(list);

        }
    }
}
