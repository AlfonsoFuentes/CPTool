using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById
{
    
    public class GetByIdPipeAccesoryQuery : GetByIdQuery, IRequest<AddEditPipeAccesoryCommand>
    {
    }
    public class GetByIdPipeAccesoryQueryHandler : IRequestHandler<GetByIdPipeAccesoryQuery, AddEditPipeAccesoryCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeAccesoryQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditPipeAccesoryCommand> Handle(GetByIdPipeAccesoryQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipeAccesory>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditPipeAccesoryCommand>(table);

        }
    }
    
}
