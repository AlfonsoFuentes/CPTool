
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Query.GetList
{

    public class GetPipingItemListQuery : GetListQuery, IRequest<List<AddEditPipingItemCommand>>
    {



    }
    public class GetPipingItemListQueryHandler : IRequestHandler<GetPipingItemListQuery, List<AddEditPipingItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipingItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPipingItemCommand>> Handle(GetPipingItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipingItem>().GetAllAsync();

            return _mapper.Map<List<AddEditPipingItemCommand>>(list);

        }
    }
}
