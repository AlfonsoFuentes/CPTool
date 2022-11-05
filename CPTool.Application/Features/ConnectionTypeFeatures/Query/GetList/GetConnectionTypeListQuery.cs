
using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList
{

    public class GetConnectionTypeListQuery : GetListQuery, IRequest<List<EditConnectionType>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler :
         GetListQueryHandler<EditConnectionType, ConnectionType, GetConnectionTypeListQuery>, 
        IRequestHandler<GetConnectionTypeListQuery, List<EditConnectionType>>
    {

      
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
       
    }
}
