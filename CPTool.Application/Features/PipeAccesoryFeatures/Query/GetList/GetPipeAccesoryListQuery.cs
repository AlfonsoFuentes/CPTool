
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList
{

    public class GetPipeAccesoryListQuery : GetListQuery, IRequest<List<EditPipeAccesory>>
    {



    }
    public class GetPipeAccesoryListQueryHandler : IRequestHandler<GetPipeAccesoryListQuery, List<EditPipeAccesory>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeAccesoryListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPipeAccesory>> Handle(GetPipeAccesoryListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeAccesory>().GetAllAsync();

            return _mapper.Map<List<EditPipeAccesory>>(list);

        }
    }
}
