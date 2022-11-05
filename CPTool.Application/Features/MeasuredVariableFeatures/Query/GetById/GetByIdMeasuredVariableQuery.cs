using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetById;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Query.GetById
{

    public class GetByIdMeasuredVariableQuery : GetByIdQuery, IRequest<EditMeasuredVariable>
    {
        public GetByIdMeasuredVariableQuery() { }
       
    }
    public class GetByIdMeasuredVariableQueryHandler :
         GetByIdQueryHandler<EditMeasuredVariable, MeasuredVariable, GetByIdMeasuredVariableQuery>, 
        IRequestHandler<GetByIdMeasuredVariableQuery, EditMeasuredVariable>
    {

      
        public GetByIdMeasuredVariableQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
