using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetById;
using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetById
{

    public class GetByIdUnitQuery : GetByIdQuery, IRequest<EditUnit>
    {
        public GetByIdUnitQuery() { }
        
    }
    public class GetByIdUnitQueryHandler :
        GetByIdQueryHandler<EditUnit, CPTool.Domain.Entities.Unit, GetByIdUnitQuery>, 
        IRequestHandler<GetByIdUnitQuery, EditUnit>
    {

      
        public GetByIdUnitQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }    
    }
    
}
