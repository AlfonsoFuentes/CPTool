using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetById;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;

namespace CPTool.Application.Features.FieldLocationFeatures.Query.GetById
{

    public class GetByIdFieldLocationQuery : GetByIdQuery, IRequest<EditFieldLocation>
    {
        public GetByIdFieldLocationQuery() { }
       
    }
    public class GetByIdFieldLocationQueryHandler : GetByIdQueryHandler<EditFieldLocation, FieldLocation, GetByIdFieldLocationQuery>, 
        
        IRequestHandler<GetByIdFieldLocationQuery, EditFieldLocation>
    {

      
        public GetByIdFieldLocationQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
