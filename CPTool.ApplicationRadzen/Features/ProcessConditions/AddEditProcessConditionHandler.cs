using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.ProcessConditions
{
    internal class AddEditProcessConditionHandler : CommandHandler<EditProcessCondition, AddProcessCondition, ProcessCondition>, IRequestHandler<Command<EditProcessCondition>, IResult>
    {

        public AddEditProcessConditionHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteProcessConditionHandler : DeleteCommandHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<DeleteCommand<EditProcessCondition>, IResult>
    {

        public DeleteProcessConditionHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListProcessConditionHandler : QueryListHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<QueryList<EditProcessCondition>, List<EditProcessCondition>>
    {

        public GetListProcessConditionHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdProcessConditionHandler : QueryIdHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<QueryId<EditProcessCondition>, EditProcessCondition>

    {


        public QueryIdProcessConditionHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
