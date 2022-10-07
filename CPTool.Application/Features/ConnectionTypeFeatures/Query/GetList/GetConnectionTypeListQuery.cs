
using CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList
{

    public class GetConnectionTypeListQuery : GetListQuery, IRequest<List<AddEditConnectionTypeCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetConnectionTypeListQuery, List<AddEditConnectionTypeCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditConnectionTypeCommand>> Handle(GetConnectionTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ConnectionType>().GetAllAsync();

            return _mapper.Map<List<AddEditConnectionTypeCommand>>(list);

        }
    }
}
