using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.PipeAccesorys
{
    internal class AddEditPipeAccesoryHandler : CommandHandler<EditPipeAccesory, AddPipeAccesory, PipeAccesory>, IRequestHandler<Command<EditPipeAccesory>, IResult>
    {

        public AddEditPipeAccesoryHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePipeAccesoryHandler : DeleteCommandHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<DeleteCommand<EditPipeAccesory>, IResult>
    {

        public DeletePipeAccesoryHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPipeAccesoryHandler : QueryListHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<QueryList<EditPipeAccesory>, List<EditPipeAccesory>>
    {

        public GetListPipeAccesoryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdPipeAccesoryHandler : QueryIdHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<QueryId<EditPipeAccesory>, EditPipeAccesory>

    {


        public QueryIdPipeAccesoryHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
