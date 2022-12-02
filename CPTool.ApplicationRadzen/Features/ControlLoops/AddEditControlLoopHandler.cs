using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.ControlLoops
{
    internal class AddEditControlLoopHandler : CommandHandler<EditControlLoop, AddControlLoop, ControlLoop>, IRequestHandler<Command<EditControlLoop>, IResult>
    {

        public AddEditControlLoopHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteControlLoopHandler : DeleteCommandHandler<EditControlLoop, ControlLoop>, IRequestHandler<DeleteCommand<EditControlLoop>, IResult>
    {

        public DeleteControlLoopHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListControlLoopHandler : QueryListHandler<EditControlLoop, ControlLoop>, IRequestHandler<QueryList<EditControlLoop>, List<EditControlLoop>>
    {

        public GetListControlLoopHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdControlLoopHandler : QueryIdHandler<EditControlLoop, ControlLoop>, IRequestHandler<QueryId<EditControlLoop>, EditControlLoop>

    {


        public QueryIdControlLoopHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
