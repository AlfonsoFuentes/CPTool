using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Query.GetById;
using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Query.GetById
{

    public class GetByIdPaintingItemQuery : GetByIdQuery, IRequest<EditPaintingItem>
    {
        
    }
    public class GetByIdPaintingItemQueryHandler : 
        GetByIdQueryHandler<EditPaintingItem, PaintingItem, GetByIdPaintingItemQuery>,
        IRequestHandler<GetByIdPaintingItemQuery, EditPaintingItem>
    {

      
        public GetByIdPaintingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
