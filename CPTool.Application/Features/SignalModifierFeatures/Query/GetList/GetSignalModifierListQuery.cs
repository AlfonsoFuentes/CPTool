
using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.Query.GetList;

namespace CPTool.Application.Features.SignalModifierFeatures.Query.GetList
{

    public class GetSignalModifierListQuery : GetListQuery, IRequest<List<EditSignalModifier>>
    {



    }
    public class GetSignalModifierListQueryHandler :
           GetListQueryHandler<EditSignalModifier, SignalModifier, GetSignalModifierListQuery>,
        IRequestHandler<GetSignalModifierListQuery, List<EditSignalModifier>>
    {
        public GetSignalModifierListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
