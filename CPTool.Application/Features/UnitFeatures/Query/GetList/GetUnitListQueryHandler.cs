
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList;
using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetList
{

    public class GetUnitListQuery : GetListQuery, IRequest<List<EditUnit>>
    {



    }
    public class GetUnitListQueryHandler :
         GetListQueryHandler<EditUnit, CPTool.Domain.Entities.Unit, GetUnitListQuery>,
        IRequestHandler<GetUnitListQuery, List<EditUnit>>
    {
        public GetUnitListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
