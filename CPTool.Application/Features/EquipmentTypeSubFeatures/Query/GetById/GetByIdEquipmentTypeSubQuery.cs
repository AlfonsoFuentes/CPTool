using CPTool.Application.Features.MMOTypeFeatures.Query.GetById;

namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetById
{
    public class GetByIdEquipmentTypeSubQuery : GetByIdQuery, IRequest<EditEquipmentTypeSub>
    {
        public GetByIdEquipmentTypeSubQuery() { }
        
    }
    public class GetByIdEquipmentTypeSubQueryHandler :
         GetByIdQueryHandler<EditEquipmentTypeSub, EquipmentTypeSub, GetByIdEquipmentTypeSubQuery>, 
        IRequestHandler<GetByIdEquipmentTypeSubQuery, EditEquipmentTypeSub>
    {

      
        public GetByIdEquipmentTypeSubQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
