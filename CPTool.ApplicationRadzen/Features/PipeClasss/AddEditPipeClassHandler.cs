using CPTool.Application.Features.PipeClassFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.PipeClasss
{
    internal class AddEditPipeClassHandler : CommandHandler<EditPipeClass, AddPipeClass, PipeClass>, IRequestHandler<Command<EditPipeClass>, IResult>
    {

        public AddEditPipeClassHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePipeClassHandler : DeleteCommandHandler<EditPipeClass, PipeClass>, IRequestHandler<DeleteCommand<EditPipeClass>, IResult>
    {

        public DeletePipeClassHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPipeClassHandler : QueryListHandler<EditPipeClass, PipeClass>, IRequestHandler<QueryList<EditPipeClass>, List<EditPipeClass>>
    {

        public GetListPipeClassHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdPipeClassHandler : QueryIdHandler<EditPipeClass, PipeClass>, IRequestHandler<QueryId<EditPipeClass>, EditPipeClass>

    {


        public QueryIdPipeClassHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
