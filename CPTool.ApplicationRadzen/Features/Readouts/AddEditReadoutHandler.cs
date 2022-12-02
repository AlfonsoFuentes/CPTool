using CPTool.Application.Features.ReadoutFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Readouts
{
    internal class AddEditReadoutHandler : CommandHandler<EditReadout, AddReadout, Readout>, IRequestHandler<Command<EditReadout>, IResult>
    {

        public AddEditReadoutHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteReadoutHandler : DeleteCommandHandler<EditReadout, Readout>, IRequestHandler<DeleteCommand<EditReadout>, IResult>
    {

        public DeleteReadoutHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListReadoutHandler : QueryListHandler<EditReadout, Readout>, IRequestHandler<QueryList<EditReadout>, List<EditReadout>>
    {

        public GetListReadoutHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdReadoutHandler : QueryIdHandler<EditReadout, Readout>, IRequestHandler<QueryId<EditReadout>, EditReadout>

    {


        public QueryIdReadoutHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
