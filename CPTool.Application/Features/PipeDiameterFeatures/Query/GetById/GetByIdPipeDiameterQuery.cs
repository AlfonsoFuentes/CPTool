using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetById
{

    public class GetByIdPipeDiameterQuery : GetByIdQuery, IRequest<EditPipeDiameter>
    {
        public GetByIdPipeDiameterQuery() { }
        
    }
    public class GetByIdPipeDiameterQueryHandler :
        GetByIdQueryHandler<EditPipeDiameter, PipeDiameter, GetByIdPipeDiameterQuery>, 
        IRequestHandler<GetByIdPipeDiameterQuery, EditPipeDiameter>
    {

      
        public GetByIdPipeDiameterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
