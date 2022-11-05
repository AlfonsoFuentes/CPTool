
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetList
{

    public class GetMeasuredVariableModifierListQuery : GetListQuery, IRequest<List<EditMeasuredVariableModifier>>
    {



    }
    public class GetMeasuredVariableModifierListQueryHandler :
         GetListQueryHandler<EditMeasuredVariableModifier, MeasuredVariableModifier, GetMeasuredVariableModifierListQuery>,
        IRequestHandler<GetMeasuredVariableModifierListQuery, List<EditMeasuredVariableModifier>>
    {
        public GetMeasuredVariableModifierListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
