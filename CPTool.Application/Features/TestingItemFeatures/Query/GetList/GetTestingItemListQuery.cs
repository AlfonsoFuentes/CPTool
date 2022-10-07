
using CPTool.Application.Features.TestingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Query.GetList
{

    public class GetTestingItemListQuery : GetListQuery, IRequest<List<AddEditTestingItemCommand>>
    {



    }
    public class GetTestingItemListQueryHandler : IRequestHandler<GetTestingItemListQuery, List<AddEditTestingItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTestingItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditTestingItemCommand>> Handle(GetTestingItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TestingItem>().GetAllAsync();

            return _mapper.Map<List<AddEditTestingItemCommand>>(list);

        }
    }
}
