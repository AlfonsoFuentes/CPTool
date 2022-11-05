using CPTool.Application.Features.ReadoutFeatures.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.Query.GetById;
using CPTool.Application.Features.UserFeatures.CreateEdit;

namespace CPTool.Application.Features.UserFeatures.Query.GetById
{

    public class GetByIdUserByQuery : GetByIdQuery, IRequest<EditUser>
    {
        public GetByIdUserByQuery() { }

    }
    public class GetByIdRequestedByQuery :
        GetByIdQueryHandler<EditUser, User, GetByIdUserByQuery>,
        IRequestHandler<GetByIdUserByQuery, EditUser>
    {


        public GetByIdRequestedByQuery(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
    }
}

