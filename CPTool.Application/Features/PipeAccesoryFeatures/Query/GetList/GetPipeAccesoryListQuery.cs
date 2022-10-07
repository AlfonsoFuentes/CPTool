
using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList
{

    public class GetPipeAccesoryListQuery : GetListQuery, IRequest<List<AddEditPipeAccesoryCommand>>
    {



    }
    public class GetPipeAccesoryListQueryHandler : IRequestHandler<GetPipeAccesoryListQuery, List<AddEditPipeAccesoryCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeAccesoryListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPipeAccesoryCommand>> Handle(GetPipeAccesoryListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeAccesory>().GetAllAsync();

            return _mapper.Map<List<AddEditPipeAccesoryCommand>>(list);

        }
    }
}
