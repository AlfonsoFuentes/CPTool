using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.UserRequirements
{
    internal class AddEditUserRequirementHandler : CommandHandler<EditUserRequirement, AddUserRequirement, UserRequirement>, IRequestHandler<Command<EditUserRequirement>, IResult>
    {

        public AddEditUserRequirementHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserRequirementHandler : DeleteCommandHandler<EditUserRequirement, UserRequirement>, IRequestHandler<DeleteCommand<EditUserRequirement>, IResult>
    {

        public DeleteUserRequirementHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserRequirementHandler : QueryListHandler<EditUserRequirement, UserRequirement>, IRequestHandler<QueryList<EditUserRequirement>, List<EditUserRequirement>>
    {

        public GetListUserRequirementHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdUserRequirementHandler : QueryIdHandler<EditUserRequirement, UserRequirement>, IRequestHandler<QueryId<EditUserRequirement>, EditUserRequirement>

    {


        public QueryIdUserRequirementHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
