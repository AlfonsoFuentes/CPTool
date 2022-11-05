namespace CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit
{
    internal class UserRequirementTypeHandler : AddEditBaseHandler<AddUserRequirementType,EditUserRequirementType, UserRequirementType>, IRequestHandler<EditUserRequirementType, Result<int>>
    {


        public UserRequirementTypeHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditUserRequirementType> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
