using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;


namespace CPTool.Application.Features.UnitaryBasePrizeFeatures
{
    internal class AddEditUnitaryBasePrizeHandler : CommandHandler<EditUnitaryBasePrize, AddUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<EditUnitaryBasePrize, Result<int>>
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
        public override async Task<List<EditUnitaryBasePrize>> Handle(QueryList<EditUnitaryBasePrize> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryUnitaryBasePrize.GetAllAsync();

            return _mapper.Map<List<EditUnitaryBasePrize>>(list);

        }
    }
    internal class QueryIdUnitaryBasePrizeHandler : QueryIdHandler<EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<QueryId<EditUnitaryBasePrize>, EditUnitaryBasePrize>

    {


        public QueryIdUnitaryBasePrizeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditUnitaryBasePrize> Handle(QueryId<EditUnitaryBasePrize> request, CancellationToken cancellationToken)
        {
            EditUnitaryBasePrize result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryUnitaryBasePrize.GetByIdAsync(request.Id);


                result = _mapper.Map<EditUnitaryBasePrize>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelUnitaryBasePrizeHandler : QueryExcelHandler<EditUnitaryBasePrize>, IRequestHandler<QueryExcel<EditUnitaryBasePrize>, QueryExcel<EditUnitaryBasePrize>>

    {


        public QueryExcelUnitaryBasePrizeHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
