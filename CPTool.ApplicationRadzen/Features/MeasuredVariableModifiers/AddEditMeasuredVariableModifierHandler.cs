using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.MeasuredVariableModifiers
{
    internal class AddEditMeasuredVariableModifierHandler : CommandHandler<EditMeasuredVariableModifier, AddMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<Command<EditMeasuredVariableModifier>, IResult>
    {

        public AddEditMeasuredVariableModifierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMeasuredVariableModifierHandler : DeleteCommandHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<DeleteCommand<EditMeasuredVariableModifier>, IResult>
    {

        public DeleteMeasuredVariableModifierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMeasuredVariableModifierHandler : QueryListHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<QueryList<EditMeasuredVariableModifier>, List<EditMeasuredVariableModifier>>
    {

        public GetListMeasuredVariableModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdMeasuredVariableModifierHandler : QueryIdHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<QueryId<EditMeasuredVariableModifier>, EditMeasuredVariableModifier>

    {


        public QueryIdMeasuredVariableModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
