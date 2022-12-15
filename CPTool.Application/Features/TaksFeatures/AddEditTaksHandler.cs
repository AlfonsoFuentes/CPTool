using CPTool.Application.Features.TaksFeatures.CreateEdit;


namespace CPTool.Application.Features.TaksFeatures
{
    internal class AddEditTaksHandler : CommandHandler<EditTaks, AddTaks, Taks>, IRequestHandler<EditTaks, Result<int>>
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
        public override async Task<EditTaks> Handle(QueryId<EditTaks> request, CancellationToken cancellationToken)
        {
            EditTaks result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryTaks.GetByIdAsync(request.Id);


                result = _mapper.Map<EditTaks>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelTaksHandler : QueryExcelHandler<EditTaks>, IRequestHandler<QueryExcel<EditTaks>, QueryExcel<EditTaks>>

    {


        public QueryExcelTaksHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
