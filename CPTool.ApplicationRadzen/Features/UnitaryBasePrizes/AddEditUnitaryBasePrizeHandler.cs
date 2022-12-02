using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.UnitaryBasePrizes
{
    internal class AddEditUnitaryBasePrizeHandler : CommandHandler<EditUnitaryBasePrize, AddUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<Command<EditUnitaryBasePrize>, IResult>
    {

        public AddEditUnitaryBasePrizeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUnitaryBasePrizeHandler : DeleteCommandHandler<EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<DeleteCommand<EditUnitaryBasePrize>, IResult>
    {

        public DeleteUnitaryBasePrizeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUnitaryBasePrizeHandler : QueryListHandler<EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<QueryList<EditUnitaryBasePrize>, List<EditUnitaryBasePrize>>
    {

        public GetListUnitaryBasePrizeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdUnitaryBasePrizeHandler : QueryIdHandler<EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<QueryId<EditUnitaryBasePrize>, EditUnitaryBasePrize>

    {


        public QueryIdUnitaryBasePrizeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
