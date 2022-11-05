using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Query.GetById;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;


namespace CPTool.Application.Features.MaterialFeatures.Query.GetById
{

    public class GetByIdMaterialQuery : GetByIdQuery, IRequest<EditMaterial>
    {
        public GetByIdMaterialQuery() { }
       
    }
    public class GetByIdMaterialQueryHandler :
        GetByIdQueryHandler<EditMaterial, Material, GetByIdMaterialQuery>, 
        IRequestHandler<GetByIdMaterialQuery, EditMaterial>
    {

      
        public GetByIdMaterialQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
