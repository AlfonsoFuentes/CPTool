
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Query.GetList
{

    public class GetPipeClassListQuery : GetListQuery, IRequest<List<AddEditPipeClassCommand>>
    {



    }
    public class GetPipeClassListQueryHandler : IRequestHandler<GetPipeClassListQuery, List<AddEditPipeClassCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeClassListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPipeClassCommand>> Handle(GetPipeClassListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeClass>().GetAllAsync();

            return _mapper.Map<List<AddEditPipeClassCommand>>(list);

        }
    }
}
