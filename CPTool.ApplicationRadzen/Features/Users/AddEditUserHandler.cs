using CPTool.Application.Features.UserFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Users
{
    internal class AddEditUserHandler : CommandHandler<EditUser, AddUser, User>, IRequestHandler<Command<EditUser>, IResult>
    {

        public AddEditUserHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserHandler : DeleteCommandHandler<EditUser, User>, IRequestHandler<DeleteCommand<EditUser>, IResult>
    {

        public DeleteUserHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserHandler : QueryListHandler<EditUser, User>, IRequestHandler<QueryList<EditUser>, List<EditUser>>
    {

        public GetListUserHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdUserHandler : QueryIdHandler<EditUser, User>, IRequestHandler<QueryId<EditUser>, EditUser>

    {


        public QueryIdUserHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
