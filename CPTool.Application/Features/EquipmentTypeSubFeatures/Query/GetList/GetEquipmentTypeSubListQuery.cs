using CPTool.Application.Features.MMOTypeFeatures.Query.GetList;

namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList
{
    public class GetEquipmentTypeSubListQuery : GetListQuery, IRequest<List<EditEquipmentTypeSub>>
    {

       
       
    }
    public class GetEquipmentTypeSubListQueryHandler :
         GetListQueryHandler<EditEquipmentTypeSub, EquipmentTypeSub, GetEquipmentTypeSubListQuery>, 
        IRequestHandler<GetEquipmentTypeSubListQuery, List<EditEquipmentTypeSub>>
    {

     
        public GetEquipmentTypeSubListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
}
