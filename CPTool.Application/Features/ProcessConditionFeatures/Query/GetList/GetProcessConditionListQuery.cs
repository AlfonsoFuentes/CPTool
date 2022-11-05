
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetList;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Query.GetList
{

    public class GetProcessConditionListQuery : GetListQuery, IRequest<List<EditProcessCondition>>
    {



    }
    public class GetProcessConditionListQueryHandler :
         GetListQueryHandler<EditProcessCondition, ProcessCondition, GetProcessConditionListQuery>,
        IRequestHandler<GetProcessConditionListQuery, List<EditProcessCondition>>
    {
        public GetProcessConditionListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
