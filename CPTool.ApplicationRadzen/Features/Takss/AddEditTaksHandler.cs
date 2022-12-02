using CPTool.Application.Features.TaksFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Takss
{
    internal class AddEditTaksHandler : CommandHandler<EditTaks, AddTaks, Taks>, IRequestHandler<Command<EditTaks>, IResult>
    {

        public AddEditTaksHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteTaksHandler : DeleteCommandHandler<EditTaks, Taks>, IRequestHandler<DeleteCommand<EditTaks>, IResult>
    {

        public DeleteTaksHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListTaksHandler : QueryListHandler<EditTaks, Taks>, IRequestHandler<QueryList<EditTaks>, List<EditTaks>>
    {

        public GetListTaksHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditTaks>> Handle(QueryList<EditTaks> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Taks>().GetAllAsync();
            list = list.OrderBy(x => x.TaksStatus).ToList();
            return _mapper.Map<List<EditTaks>>(list);


        }

    }
    internal class QueryIdTaksHandler : QueryIdHandler<EditTaks, Taks>, IRequestHandler<QueryId<EditTaks>, EditTaks>

    {


        public QueryIdTaksHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
