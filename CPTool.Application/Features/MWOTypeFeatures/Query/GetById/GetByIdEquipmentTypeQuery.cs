using CPTool.Application.Features.EquipmentTypeFeatures.Query.GetById;

namespace CPTool.Application.Features.MMOTypeFeatures.Query.GetById
{

    public class GetByIdMWOTypeQuery : GetByIdQuery, IRequest<EditMWOType>
    {
        public GetByIdMWOTypeQuery() { }
       
    }
    public class GetByIdMWOTypeQueryHandler :
       
        GetByIdQueryHandler<EditMWOType, MWOType, GetByIdMWOTypeQuery>, 
        
        IRequestHandler<GetByIdMWOTypeQuery, EditMWOType>
    {

      
        public GetByIdMWOTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
