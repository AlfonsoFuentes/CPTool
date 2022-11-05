using CPTool.Application.Features.SignalFeatures.Query.GetById;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalTypeFeatures.Query.GetById
{

    public class GetByIdSignalTypeQuery : GetByIdQuery, IRequest<EditSignalType>
    {
        public GetByIdSignalTypeQuery() { }
       
    }
    public class GetByIdSignalTypeQueryHandler :
         GetByIdQueryHandler<EditSignalType, SignalType, GetByIdSignalTypeQuery>, 
        IRequestHandler<GetByIdSignalTypeQuery, EditSignalType>
    {

      
        public GetByIdSignalTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
