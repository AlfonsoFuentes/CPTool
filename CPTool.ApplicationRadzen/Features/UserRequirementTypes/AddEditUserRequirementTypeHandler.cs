using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.UserRequirementTypes
{
    internal class AddEditUserRequirementTypeHandler : CommandHandler<EditUserRequirementType, AddUserRequirementType, UserRequirementType>, IRequestHandler<Command<EditUserRequirementType>, IResult>
    {

        public AddEditUserRequirementTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserRequirementTypeHandler : DeleteCommandHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<DeleteCommand<EditUserRequirementType>, IResult>
    {

        public DeleteUserRequirementTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserRequirementTypeHandler : QueryListHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<QueryList<EditUserRequirementType>, List<EditUserRequirementType>>
    {

        public GetListUserRequirementTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdUserRequirementTypeHandler : QueryIdHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<QueryId<EditUserRequirementType>, EditUserRequirementType>

    {


        public QueryIdUserRequirementTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
