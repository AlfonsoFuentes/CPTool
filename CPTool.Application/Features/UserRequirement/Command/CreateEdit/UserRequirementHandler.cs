namespace CPTool.Application.Features.UserRequirementFeatures.CreateEdit
{
    internal class UserRequirementHandler : AddEditBaseHandler<AddUserRequirement,EditUserRequirement, UserRequirement>, IRequestHandler<EditUserRequirement, Result<int>>
    {


        public UserRequirementHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditUserRequirement> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
