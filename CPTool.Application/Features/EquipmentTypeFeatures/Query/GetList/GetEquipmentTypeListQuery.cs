

using CPTool.Application.Features.ElectricalBoxFeatures.Query.GetList;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentTypeFeatures.Query.GetList
{
   
    public class GetEquipmentTypeListQuery : GetListQuery, IRequest<List<EditEquipmentType>>
    {
        public GetEquipmentTypeListQuery()
        {
        }

      

    }
    public class GetEquipmentTypeListQueryHandler :
         GetListQueryHandler<EditEquipmentType, EquipmentType, GetEquipmentTypeListQuery>, 
        IRequestHandler<GetEquipmentTypeListQuery, List<EditEquipmentType>>
    {

      
        public GetEquipmentTypeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
    }
}
