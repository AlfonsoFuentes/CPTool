
using CPTool.Application.Features.GasketsFeatures.CreateEdit;

namespace CPTool.Application.Features.GasketFeatures.Query.GetList
{

    public class GetGasketListQuery : GetListQuery, IRequest<List<EditGasket>>
    {



    }
    public class GetGasketListQueryHandler :
        GetListQueryHandler<EditGasket, Gasket, GetGasketListQuery>,
        IRequestHandler<GetGasketListQuery, List<EditGasket>>
    {
        public GetGasketListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
