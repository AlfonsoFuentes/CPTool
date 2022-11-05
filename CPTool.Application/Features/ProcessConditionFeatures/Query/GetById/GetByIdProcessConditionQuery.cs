using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Query.GetById;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Query.GetById
{

    public class GetByIdProcessConditionQuery : GetByIdQuery, IRequest<EditProcessCondition>
    {
        public GetByIdProcessConditionQuery() { }
        
    }
    public class GetByIdProcessConditionQueryHandler : 
        GetByIdQueryHandler<EditProcessCondition, ProcessCondition, GetByIdProcessConditionQuery>,
        IRequestHandler<GetByIdProcessConditionQuery, EditProcessCondition>
    {

      
        public GetByIdProcessConditionQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
