using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Query.GetById
{
    
    public class GetByIdPipingItemQuery : GetByIdQuery, IRequest<AddEditPipingItemCommand>
    {
    }
    public class GetByIdPipingItemQueryHandler : IRequestHandler<GetByIdPipingItemQuery, AddEditPipingItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditPipingItemCommand> Handle(GetByIdPipingItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipingItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditPipingItemCommand>(table);

        }
    }
    
}
