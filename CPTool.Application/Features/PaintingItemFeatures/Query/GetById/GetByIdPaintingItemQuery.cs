using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Query.GetById
{

    public class GetByIdPaintingItemQuery : GetByIdQuery, IRequest<EditPaintingItem>
    {
        
    }
    public class GetByIdPaintingItemQueryHandler : IRequestHandler<GetByIdPaintingItemQuery, EditPaintingItem>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPaintingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPaintingItem> Handle(GetByIdPaintingItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PaintingItem>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPaintingItem>(table);

        }
    }
    
}
