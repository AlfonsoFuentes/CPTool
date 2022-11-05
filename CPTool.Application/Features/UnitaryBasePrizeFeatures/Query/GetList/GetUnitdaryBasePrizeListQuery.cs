
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList
{

    public class GetUnitaryBasePrizeListQuery : GetListQuery, IRequest<List<EditUnitaryBasePrize>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler :
         GetListQueryHandler<EditUnitaryBasePrize, UnitaryBasePrize, GetUnitaryBasePrizeListQuery>,
        IRequestHandler<GetUnitaryBasePrizeListQuery, List<EditUnitaryBasePrize>>
    {
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
