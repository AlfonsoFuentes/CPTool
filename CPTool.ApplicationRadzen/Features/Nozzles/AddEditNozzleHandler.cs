using CPTool.Application.Features.NozzleFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Nozzles
{
    internal class AddEditNozzleHandler : CommandHandler<EditNozzle, AddNozzle, Nozzle>, IRequestHandler<Command<EditNozzle>, IResult>
    {

        public AddEditNozzleHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteNozzleHandler : DeleteCommandHandler<EditNozzle, Nozzle>, IRequestHandler<DeleteCommand<EditNozzle>, IResult>
    {

        public DeleteNozzleHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListNozzleHandler : QueryListHandler<EditNozzle, Nozzle>, IRequestHandler<QueryList<EditNozzle>, List<EditNozzle>>
    {

        public GetListNozzleHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdNozzleHandler : QueryIdHandler<EditNozzle, Nozzle>, IRequestHandler<QueryId<EditNozzle>, EditNozzle>

    {


        public QueryIdNozzleHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
