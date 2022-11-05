
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementFeatures.Query.GetList
{

    public class GetUserRequirementListQuery : GetListQuery, IRequest<List<EditUserRequirement>>
    {



    }
    public class GetUserRequirementListQueryHandler :
          GetListQueryHandler<EditUserRequirement, UserRequirement, GetUserRequirementListQuery>,
        IRequestHandler<GetUserRequirementListQuery, List<EditUserRequirement>>
    {
        public GetUserRequirementListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
