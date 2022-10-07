
using CPTool.Application.Features.FoundationItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Query.GetList
{

    public class GetFoundationItemListQuery : GetListQuery, IRequest<List<AddEditFoundationItemCommand>>
    {



    }
    public class GetFoundationItemListQueryHandler : IRequestHandler<GetFoundationItemListQuery, List<AddEditFoundationItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetFoundationItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditFoundationItemCommand>> Handle(GetFoundationItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<FoundationItem>().GetAllAsync();

            return _mapper.Map<List<AddEditFoundationItemCommand>>(list);

        }
    }
}
