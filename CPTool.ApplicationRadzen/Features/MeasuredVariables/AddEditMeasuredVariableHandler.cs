using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.MeasuredVariables
{
    internal class AddEditMeasuredVariableHandler : CommandHandler<EditMeasuredVariable, AddMeasuredVariable, MeasuredVariable>, IRequestHandler<Command<EditMeasuredVariable>, IResult>
    {

        public AddEditMeasuredVariableHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMeasuredVariableHandler : DeleteCommandHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<DeleteCommand<EditMeasuredVariable>, IResult>
    {

        public DeleteMeasuredVariableHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMeasuredVariableHandler : QueryListHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<QueryList<EditMeasuredVariable>, List<EditMeasuredVariable>>
    {

        public GetListMeasuredVariableHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdMeasuredVariableHandler : QueryIdHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<QueryId<EditMeasuredVariable>, EditMeasuredVariable>

    {


        public QueryIdMeasuredVariableHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
