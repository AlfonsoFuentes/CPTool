

using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;

namespace CPTool.Application.Features.FieldLocationFeatures.Query.GetList
{

    public class GetFieldLocationListQuery : GetListQuery, IRequest<List<EditFieldLocation>>
    {



    }
    public class GetFieldLocationListQueryHandler :
          GetListQueryHandler<EditFieldLocation, FieldLocation, GetFieldLocationListQuery>, 
        IRequestHandler<GetFieldLocationListQuery, List<EditFieldLocation>>
    {

   
        public GetFieldLocationListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
}
