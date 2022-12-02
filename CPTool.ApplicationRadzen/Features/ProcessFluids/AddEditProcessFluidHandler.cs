using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.ProcessFluids
{
    internal class AddEditProcessFluidHandler : CommandHandler<EditProcessFluid, AddProcessFluid, ProcessFluid>, IRequestHandler<Command<EditProcessFluid>, IResult>
    {

        public AddEditProcessFluidHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteProcessFluidHandler : DeleteCommandHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<DeleteCommand<EditProcessFluid>, IResult>
    {

        public DeleteProcessFluidHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListProcessFluidHandler : QueryListHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<QueryList<EditProcessFluid>, List<EditProcessFluid>>
    {

        public GetListProcessFluidHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdProcessFluidHandler : QueryIdHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<QueryId<EditProcessFluid>, EditProcessFluid>

    {


        public QueryIdProcessFluidHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
