using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Query.GetById;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetById
{

    public class GetByIdMeasuredVariableModifierQuery : GetByIdQuery, IRequest<EditMeasuredVariableModifier>
    {
        public GetByIdMeasuredVariableModifierQuery() { }
       
    }
    public class GetByIdMeasuredVariableModifierQueryHandler :
         GetByIdQueryHandler<EditMeasuredVariableModifier, MeasuredVariableModifier, GetByIdMeasuredVariableModifierQuery>,

        IRequestHandler<GetByIdMeasuredVariableModifierQuery, EditMeasuredVariableModifier>
    {

       
        public GetByIdMeasuredVariableModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
