
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Query.GetList
{

    public class GetTaksListQuery : GetListQuery, IRequest<List<EditTaks>>
    {



    }
    public class GetTaksListQueryHandler : IRequestHandler<GetTaksListQuery, List<EditTaks>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTaksListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditTaks>> Handle(GetTaksListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Taks>().GetAllAsync();
            list = list.OrderBy(x => x.TaksStatus).ToList();
            return _mapper.Map<List<EditTaks>>(list);

        }
    }
}
