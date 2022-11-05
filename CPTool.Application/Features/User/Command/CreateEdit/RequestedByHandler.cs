namespace CPTool.Application.Features.UserFeatures.CreateEdit
{
    internal class UserHandler : AddEditBaseHandler<AddUser,EditUser, User>, IRequestHandler<EditUser, Result<int>>
    {


        public UserHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditUser> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
