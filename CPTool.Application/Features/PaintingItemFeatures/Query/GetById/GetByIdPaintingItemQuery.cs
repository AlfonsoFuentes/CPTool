using CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Query.GetById
{
    
    public class GetByIdPaintingItemQuery : GetByIdQuery, IRequest<AddEditPaintingItemCommand>
    {
    }
    public class GetByIdPaintingItemQueryHandler : IRequestHandler<GetByIdPaintingItemQuery, AddEditPaintingItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPaintingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditPaintingItemCommand> Handle(GetByIdPaintingItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PaintingItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditPaintingItemCommand>(table);

        }
    }
    
}
