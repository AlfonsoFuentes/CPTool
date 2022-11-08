using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.Query.GetById;

namespace CPTool.Application.Features.SignalModifierFeatures.Query.GetById
{

    public class GetByIdSignalModifierQuery : GetByIdQuery, IRequest<EditSignalModifier>
    {
        public GetByIdSignalModifierQuery() { }
       
    }
    public class GetByIdSignalModifierQueryHandler :
         GetByIdQueryHandler<EditSignalModifier, SignalModifier, GetByIdSignalModifierQuery>, 
        IRequestHandler<GetByIdSignalModifierQuery, EditSignalModifier>
    {

       
        public GetByIdSignalModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
