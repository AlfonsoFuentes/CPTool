
using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList
{

    public class GetConnectionTypeListQuery : GetListQuery, IRequest<List<EditConnectionType>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetConnectionTypeListQuery, List<EditConnectionType>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditConnectionType>> Handle(GetConnectionTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ConnectionType>().GetAllAsync();

            return _mapper.Map<List<EditConnectionType>>(list);

        }
    }
}
