
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetList
{

    public class GetInstrumentItemListQuery : GetListQuery, IRequest<List<EditInstrumentItem>>
    {



    }
    public class GetInstrumentItemListQueryHandler :
        GetListQueryHandler<EditInstrumentItem, InstrumentItem, GetInstrumentItemListQuery>,
        IRequestHandler<GetInstrumentItemListQuery, List<EditInstrumentItem>>
    {
        public GetInstrumentItemListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
