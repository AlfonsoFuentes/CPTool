
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetList;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementTypeFeatures.Query.GetList
{

    public class GetUserRequirementTypeListQuery : GetListQuery, IRequest<List<EditUserRequirementType>>
    {



    }
    public class GetUserRequirementTypeListQueryHandler :
         GetListQueryHandler<EditUserRequirementType, UserRequirementType, GetUserRequirementTypeListQuery>,
        IRequestHandler<GetUserRequirementTypeListQuery, List<EditUserRequirementType>>
    {
        public GetUserRequirementTypeListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
