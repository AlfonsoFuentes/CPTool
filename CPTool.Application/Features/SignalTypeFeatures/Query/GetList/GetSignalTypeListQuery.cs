
using CPTool.Application.Features.SignalFeatures.Query.GetList;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalTypeFeatures.Query.GetList
{

    public class GetSignalTypeListQuery : GetListQuery, IRequest<List<EditSignalType>>
    {



    }
    public class GetSignalTypeListQueryHandler :
         GetListQueryHandler<EditSignalType, SignalType, GetSignalTypeListQuery>,
        IRequestHandler<GetSignalTypeListQuery, List<EditSignalType>>
    {
        public GetSignalTypeListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
