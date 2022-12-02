using CPTool.Application.Features.WireFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Wires
{
    internal class AddEditWireHandler : CommandHandler<EditWire, AddWire, Wire>, IRequestHandler<Command<EditWire>, IResult>
    {

        public AddEditWireHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteWireHandler : DeleteCommandHandler<EditWire, Wire>, IRequestHandler<DeleteCommand<EditWire>, IResult>
    {

        public DeleteWireHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListWireHandler : QueryListHandler<EditWire, Wire>, IRequestHandler<QueryList<EditWire>, List<EditWire>>
    {

        public GetListWireHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdWireHandler : QueryIdHandler<EditWire, Wire>, IRequestHandler<QueryId<EditWire>, EditWire>

    {


        public QueryIdWireHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
