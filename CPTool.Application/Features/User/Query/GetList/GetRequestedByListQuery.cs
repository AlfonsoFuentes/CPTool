
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.Query.GetList;
using CPTool.Application.Features.UserFeatures.CreateEdit;

namespace CPTool.Application.Features.UserFeatures.Query.GetList
{

    public class GetUserListQuery : GetListQuery, IRequest<List<EditUser>>
    {



    }
    public class GetUserListQueryHandler :
          GetListQueryHandler<EditUser, User, GetUserListQuery>,
        IRequestHandler<GetUserListQuery, List<EditUser>>
    {
        public GetUserListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
