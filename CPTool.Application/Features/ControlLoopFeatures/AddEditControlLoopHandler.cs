using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;


namespace CPTool.Application.Features.ControlLoopFeatures
{
    internal class AddEditControlLoopHandler : CommandHandler<EditControlLoop, AddControlLoop, ControlLoop>, IRequestHandler<EditControlLoop, Result<int>>
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
        public override async Task<List<EditControlLoop>> Handle(QueryList<EditControlLoop> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryControlLoop.GetAllAsync();

            return _mapper.Map<List<EditControlLoop>>(list);

        }
    }
    internal class QueryIdControlLoopHandler : QueryIdHandler<EditControlLoop, ControlLoop>, IRequestHandler<QueryId<EditControlLoop>, EditControlLoop>

    {


        public QueryIdControlLoopHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditControlLoop> Handle(QueryId<EditControlLoop> request, CancellationToken cancellationToken)
        {
            EditControlLoop result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryControlLoop.GetByIdAsync(request.Id);


                result = _mapper.Map<EditControlLoop>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelControlLoopHandler : QueryExcelHandler<EditControlLoop>, IRequestHandler<QueryExcel<EditControlLoop>, QueryExcel<EditControlLoop>>

    {


        public QueryExcelControlLoopHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
