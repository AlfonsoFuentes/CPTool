using CPTool.Application.Features.EquipmentTypeFeatures.Query.GetList;

namespace CPTool.Application.Features.MMOTypeFeatures.Query.GetList
{

    public class GetMWOTypeListQuery : GetListQuery, IRequest<List<EditMWOType>>
    {
       

       
    }
    public class GetMWOTypeListQueryHandler :
         GetListQueryHandler<EditMWOType, MWOType, GetMWOTypeListQuery>, 
        IRequestHandler<GetMWOTypeListQuery, List<EditMWOType>>
    {

       
        public GetMWOTypeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
}
