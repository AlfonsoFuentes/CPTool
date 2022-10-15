
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Query.GetList
{

    public class GetPipeClassListQuery : GetListQuery, IRequest<List<EditPipeClass>>
    {



    }
    public class GetPipeClassListQueryHandler : IRequestHandler<GetPipeClassListQuery, List<EditPipeClass>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeClassListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPipeClass>> Handle(GetPipeClassListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeClass>().GetAllAsync();

            return _mapper.Map<List<EditPipeClass>>(list);

        }
    }
}
