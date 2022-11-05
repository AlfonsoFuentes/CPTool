using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetById;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetById
{

    public class GetByIdUnitaryBasePrizeQuery : GetByIdQuery, IRequest<EditUnitaryBasePrize>
    {
        public GetByIdUnitaryBasePrizeQuery() { }
        
    }
    public class GetByIdUnitaryBasePrizeQueryHandler :
         GetByIdQueryHandler<EditUnitaryBasePrize, UnitaryBasePrize, GetByIdUnitaryBasePrizeQuery>, 
        IRequestHandler<GetByIdUnitaryBasePrizeQuery, EditUnitaryBasePrize>
    {

      
        public GetByIdUnitaryBasePrizeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
