
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.Query.GetList;

namespace CPTool.Application.Features.SignalFeatures.Query.GetList
{

    public class GetSignalListQuery : GetListQuery, IRequest<List<EditSignal>>
    {

        

    }
    public class GetSignalListQueryHandler :
           GetListQueryHandler<EditSignal, Signal, GetSignalListQuery>,
        IRequestHandler<GetSignalListQuery, List<EditSignal>>
    {
        public GetSignalListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
