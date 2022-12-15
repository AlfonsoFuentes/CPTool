
using CPTool.Application.Features.UnitFeatures.CreateEdit;



namespace CPTool.Application.Features.UnitFeatures
{
    internal class AddEditUnitHandler : CommandHandler<EditUnit, AddUnit, EntityUnit>, IRequestHandler<EditUnit, Result<int>>
    {

        public AddEditUnitHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUnitHandler : DeleteCommandHandler<EditUnit, EntityUnit>, IRequestHandler<DeleteCommand<EditUnit>, IResult>
    {

        public DeleteUnitHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUnitHandler : QueryListHandler<EditUnit, EntityUnit>, IRequestHandler<QueryList<EditUnit>, List<EditUnit>>
    {

        public GetListUnitHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditUnit>> Handle(QueryList<EditUnit> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryEntityUnit.GetAllAsync();

            return _mapper.Map<List<EditUnit>>(list);

        }
    }
    internal class QueryIdUnitHandler : QueryIdHandler<EditUnit, EntityUnit>, IRequestHandler<QueryId<EditUnit>, EditUnit>

    {


        public QueryIdUnitHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditUnit> Handle(QueryId<EditUnit> request, CancellationToken cancellationToken)
        {
            EditUnit result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryEntityUnit.GetByIdAsync(request.Id);


                result = _mapper.Map<EditUnit>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelUnitHandler : QueryExcelHandler<EditUnit>, IRequestHandler<QueryExcel<EditUnit>, QueryExcel<EditUnit>>

    {


        public QueryExcelUnitHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
