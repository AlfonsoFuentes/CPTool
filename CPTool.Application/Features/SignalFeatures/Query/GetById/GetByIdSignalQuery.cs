using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.Query.GetById;

namespace CPTool.Application.Features.SignalFeatures.Query.GetById
{

    public class GetByIdSignalQuery : GetByIdQuery, IRequest<EditSignal>
    {
        public GetByIdSignalQuery() { }
       
    }
    public class GetByIdSignalQueryHandler :
         GetByIdQueryHandler<EditSignal, Signal, GetByIdSignalQuery>, 
        IRequestHandler<GetByIdSignalQuery, EditSignal>
    {

       
        public GetByIdSignalQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
