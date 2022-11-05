using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Query.GetById;

namespace CPTool.Application.Features.EquipmentTypeFeatures.Query.GetById
{
    public class GetByIdEquipmentTypeQuery : GetByIdQuery, IRequest<EditEquipmentType>
    {
        public GetByIdEquipmentTypeQuery() { }
        
    }
    public class GetByIdEquipmentTypeQueryHandler : GetByIdQueryHandler<EditEquipmentType, EquipmentType, GetByIdEquipmentTypeQuery>, 
        IRequestHandler<GetByIdEquipmentTypeQuery, EditEquipmentType>
    {

      
        public GetByIdEquipmentTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
