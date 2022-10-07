using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Query.GetById
{
    
    public class GetByIdPipeClassQuery : GetByIdQuery, IRequest<AddEditPipeClassCommand>
    {
    }
    public class GetByIdPipeClassQueryHandler : IRequestHandler<GetByIdPipeClassQuery, AddEditPipeClassCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeClassQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditPipeClassCommand> Handle(GetByIdPipeClassQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipeClass>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditPipeClassCommand>(table);

        }
    }
    
}
